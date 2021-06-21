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

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new PositionDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    MaxSalary = x.MaxSalary,
                    MinSalary = x.MinSalary,
                    RiskLevel = x.RiskLevel,
                    IsActive = x.IsActive
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<PositionDto>> GetById(int id)
        {
            var result = new ServiceResult<PositionDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new PositionDto
            {
                Id = data.Id,
                Name = data.Name,
                MaxSalary = data.MaxSalary,
                MinSalary = data.MinSalary,
                RiskLevel = data.RiskLevel,
                IsActive = data.IsActive
            };

            return result;
        }

        public async Task<ServiceResult<PositionDto>> Create(PositionParameter parameter)
        {
            var result = new ServiceResult<PositionDto>();

            try
            {
                var data = new Position
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

        public async Task<ServiceResult<PositionDto>> Edit(PositionParameter parameter)
        {
            var result = new ServiceResult<PositionDto>();

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
