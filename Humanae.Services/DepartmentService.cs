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
    public class DepartmentService : IDepartmentService
    {
        private readonly IRepository<Department> _repository;

        public DepartmentService(IRepository<Department> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<IEnumerable<DepartmentDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<DepartmentDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new DepartmentDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<DepartmentDto>> GetById(int id)
        {
            var result = new ServiceResult<DepartmentDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new DepartmentDto
            {
                Id = data.Id,
                Name = data.Name,
                IsActive = data.IsActive
            };

            return result;
        }

        public async Task<ServiceResult<DepartmentDto>> Create(DepartmentParameter parameter)
        {
            var result = new ServiceResult<DepartmentDto>();

            try
            {
                var data = new Department
                {
                    Name = parameter.Name
                };

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

        public async Task<ServiceResult<DepartmentDto>> Edit(DepartmentParameter parameter)
        {
            var result = new ServiceResult<DepartmentDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Name = parameter.Name;

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

            var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id && !x.IsActive);

            if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.Name))
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
