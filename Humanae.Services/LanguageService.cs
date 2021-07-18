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
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _repository;
        private readonly IRepository<ApplicantLanguage> _repository1;

        public LanguageService(IRepository<Language> repository,
            IRepository<ApplicantLanguage> repository1)
        {
            _repository = repository;
            _repository1 = repository1;
        }

        public async Task<ServiceResult> Create(LanguageParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var data = new Language
                {
                    Name = parameter.Name
                };

                await _repository.AddAsync(data);
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

        public async Task<ServiceResult> Edit(LanguageParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Name = parameter.Name;

                await _repository.UpdateAsync(modelToUpdate);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult<List<LanguageDto>>> GetAll()
        {
            var result = new ServiceResult<List<LanguageDto>>();

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

        public async Task<ServiceResult<List<LanguageDto>>> GetApplicantLanguages(int applicantId)
        {
            var result = new ServiceResult<List<LanguageDto>>();

            var data = await _repository1.Entity()
                .Where(x => x.ApplicantId == applicantId)
                .Select(x => new LanguageDto
                {
                    Id = x.LanguageId,
                    Name = x.Language.Name,
                    IsActive = x.Language.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult> AssignToApplicant(int applicantId, int languageId)
        {
            var result = new ServiceResult();

            var assignationData = new ApplicantLanguage
            {
                ApplicantId = applicantId,
                LanguageId = languageId
            };

            try
            {
                await _repository1.AddAsync(assignationData);
            }
            catch(Exception ex)
            {
                result.AddErrorMessage(ex);
            }

            return result;
        }
    }
}
