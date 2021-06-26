using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Humanae.Services
{
    public class ApplicantService : IApplicantService
    {
        private readonly IRepository<Applicant> _repository;

        public ApplicantService(IRepository<Applicant> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<IEnumerable<ApplicantDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<ApplicantDto>>();

            var data = await _repository.Entity()
                .Select(x => new ApplicantDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    RecommendedBy = x.RecommendedBy,
                    AppliedPositionId = x.AppliedPositionId,
                    AppliedPosition = x.AppliedPosition.Name,
                    DepartmentId = x.AppliedPosition.DepartmentId,
                    Department = x.AppliedPosition.Department.Name,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult<ApplicantDto>> GetById(int id)
        {
            var result = new ServiceResult<ApplicantDto>();

            var data = await _repository.Entity()
                .Select(x => new ApplicantDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    RecommendedBy = x.RecommendedBy,
                    AppliedPositionId = x.AppliedPositionId,
                    AppliedPosition = x.AppliedPosition.Name,
                    DepartmentId = x.AppliedPosition.DepartmentId,
                    Department = x.AppliedPosition.Department.Name,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult> Create(ApplicantParameter parameter)
        {
            var result = new ServiceResult();

                var data = new Applicant
                {
                    FirstName = parameter.FirstName,
                    LastName = parameter.LastName,
                    Identification = parameter.Identification,
                    AppliedPositionId = parameter.AppliedPositionId,
                    RecommendedBy = parameter.RecommendedBy
                };

            try
            {
                await _repository.AddAsync(data);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Edit(ApplicantParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.FirstName = parameter.FirstName;
                modelToUpdate.LastName = parameter.LastName;
                modelToUpdate.Identification = parameter.Identification;
                modelToUpdate.AppliedPositionId = parameter.AppliedPositionId;
                modelToUpdate.RecommendedBy = parameter.RecommendedBy;

                await _repository.UpdateAsync(modelToUpdate);
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
