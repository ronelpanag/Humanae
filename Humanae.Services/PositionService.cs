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
    public class PositionService : IPositionService
    {
        private readonly IRepository<Position> _repository;

        public PositionService(IRepository<Position> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<IEnumerable<PositionDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<PositionDto>>();

            var data = await _repository.Entity()
                .Select(x => new PositionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    MaxSalary = x.MaxSalary,
                    MinSalary = x.MinSalary,
                    RiskLevel = x.RiskLevel,
                    DepartmentId = x.DepartmentId,
                    Department = x.Department.Name,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult<PositionDto>> GetById(int id)
        {
            var result = new ServiceResult<PositionDto>();

            var data = await _repository.Entity()
                .Select(x => new PositionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    MaxSalary = x.MaxSalary,
                    MinSalary = x.MinSalary,
                    RiskLevel = x.RiskLevel,
                    DepartmentId = x.DepartmentId,
                    Department = x.Department.Name,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult> Create(PositionParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var data = new Position
                {
                    Name = parameter.Name,
                    MinSalary = parameter.MinSalary,
                    MaxSalary = parameter.MaxSalary,
                    RiskLevel = parameter.RiskLevel,
                    DepartmentId = parameter.DepartmentId
                };

                await _repository.AddAsync(data);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Edit(PositionParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Name = parameter.Name;
                modelToUpdate.MinSalary = parameter.MinSalary;
                modelToUpdate.MaxSalary = parameter.MaxSalary;
                modelToUpdate.RiskLevel = parameter.RiskLevel;
                modelToUpdate.DepartmentId = parameter.DepartmentId;

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
