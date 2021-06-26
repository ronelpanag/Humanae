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
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _repository;

        public LanguageService(IRepository<Language> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<LanguageDto>> Create(LanguageParameter parameter)
        {
            var result = new ServiceResult<LanguageDto>();

            try
            {
                var data = new Language
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

        public async Task<ServiceResult<LanguageDto>> Edit(LanguageParameter parameter)
        {
            var result = new ServiceResult<LanguageDto>();

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

        public async Task<ServiceResult<IEnumerable<LanguageDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<LanguageDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new LanguageDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsActive = x.IsActive
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<LanguageDto>> GetById(int id)
        {
            var result = new ServiceResult<LanguageDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new LanguageDto
            {
                Id = data.Id,
                Name = data.Name,
                IsActive = data.IsActive
            };

            return result;
        }
    }
}
