using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humanae.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<Applicant> _repository;
        private readonly IPositionService _positionService;
        private readonly IDepartmentService _departmentService;

        public ApplicantService(IRepository<Applicant> repository,
            IPositionService positionService,
            IDepartmentService departmentService)
        {
            _repository = repository;
            _positionService = positionService;
            _departmentService = departmentService;
        }

        public async Task<ServiceResult<IEnumerable<ApplicantDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<ApplicantDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new ApplicantDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    RecommendedBy = x.RecommendedBy,
                    DepartmentId = x.DepartmentId,
                    AppliedPositionId = x.AppliedPositionId,
                    IsActive = x.IsActive
                })
                .ToList();

            foreach (var item in result.Data)
            {
                var department = await _departmentService.GetById(item.DepartmentId);
                var position = await _positionService.GetById(item.AppliedPositionId);

                item.Department = department.Data.Name;
                item.AppliedPosition = position.Data.Name;
            }

            return result;
        }

        public async Task<ServiceResult<ApplicantDto>> GetById(int id)
        {
            var result = new ServiceResult<ApplicantDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new ApplicantDto
            {
                Id = data.Id,
                FirstName = data.FirstName,
                LastName = data.LastName,
                Identification = data.Identification,
                RecommendedBy = data.RecommendedBy,
                DepartmentId = data.DepartmentId,
                AppliedPositionId = data.AppliedPositionId,
                IsActive = data.IsActive
            };

            var department = await _departmentService.GetById(result.Data.DepartmentId);
            var position = await _positionService.GetById(result.Data.AppliedPositionId);

            result.Data.Department = department.Data.Name;
            result.Data.AppliedPosition = position.Data.Name;

            return result;
        }

        public async Task<ServiceResult<ApplicantDto>> Create(ApplicantParameter parameter)
        {
            var result = new ServiceResult<ApplicantDto>();

                var data = new Applicant
                {
                    FirstName = parameter.FirstName,
                    LastName = parameter.LastName,
                    Identification = parameter.Identification,
                    AppliedPositionId = parameter.AppliedPositionId,
                    DepartmentId = parameter.DepartmentId,
                    RecommendedBy = parameter.RecommendedBy
                };

            try
            {
                await _repository.AddAsync(data);

                var model = await GetById(data.Id);

                result.Data = model.Data;
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult<ApplicantDto>> Edit(ApplicantParameter parameter)
        {
            var result = new ServiceResult<ApplicantDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.FirstName = parameter.FirstName;
                modelToUpdate.LastName = parameter.LastName;
                modelToUpdate.Identification = parameter.Identification;
                modelToUpdate.AppliedPositionId = parameter.AppliedPositionId;
                modelToUpdate.DepartmentId = parameter.DepartmentId;
                modelToUpdate.RecommendedBy = parameter.RecommendedBy;

                await _repository.UpdateAsync(modelToUpdate);

                var model = await GetById(modelToUpdate.Id);

                result.Data = model.Data;
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            var result = new ServiceResult();

            var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

            if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.FirstName))
            {
                result.AddErrorMessage("Mensaje de confirmación inválido.");
                return result;
            }

            modelToDelete.IsActive = false;

            try
            {
                await _repository.UpdateAsync(modelToDelete);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }
    }
}
