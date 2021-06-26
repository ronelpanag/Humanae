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
    public class TrainingService : ITrainingService
    {
        private readonly IRepository<Training> _repository;

        public TrainingService(IRepository<Training> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<TrainingDto>> Create(TrainingParameter parameter)
        {
            var result = new ServiceResult<TrainingDto>();

            var data = new Training
            {
                Description = parameter.Description,
                Institution = parameter.Institution,
                Level = parameter.Level,
                FromDate = parameter.FromDate,
                ToDate = parameter.ToDate
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

        public async Task<ServiceResult<TrainingDto>> Edit(TrainingParameter parameter)
        {
            var result = new ServiceResult<TrainingDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Description = parameter.Description;
                modelToUpdate.Institution = parameter.Institution;
                modelToUpdate.Level = parameter.Level;
                modelToUpdate.FromDate = parameter.FromDate;
                modelToUpdate.ToDate = parameter.ToDate;

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

        public async Task<ServiceResult<IEnumerable<TrainingDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<TrainingDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new TrainingDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    Institution = x.Institution,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    Level = x.Level
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<TrainingDto>> GetById(int id)
        {
            var result = new ServiceResult<TrainingDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new TrainingDto
            {
                Id = data.Id,
                Description = data.Description,
                Institution = data.Institution,
                FromDate = data.FromDate,
                ToDate = data.ToDate,
                Level = data.Level
            };

            return result;
        }

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.Description))
                {
                    result.AddErrorMessage("Mensaje de confirmación inválido.");
                    return result;
                }

                await _repository.DeleteAsync(modelToDelete);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }
    }
}
