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
    public class ExperienceService : IExperienceService
    {
        private readonly IRepository<Experience> _repository;

        public ExperienceService(IRepository<Experience> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<ExperienceDto>> Create(ExperienceParameter parameter)
        {
            var result = new ServiceResult<ExperienceDto>();

            var data = new Experience
            {
                CompanyName = parameter.CompanyName,
                JobTitle = parameter.JobTitle,
                Salary = parameter.Salary,
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

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.CompanyName))
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

        public async Task<ServiceResult<ExperienceDto>> Edit(ExperienceParameter parameter)
        {
            var result = new ServiceResult<ExperienceDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.CompanyName = parameter.CompanyName;
                modelToUpdate.JobTitle = parameter.JobTitle;
                modelToUpdate.Salary = parameter.Salary;
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

        public async Task<ServiceResult<IEnumerable<ExperienceDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<ExperienceDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new ExperienceDto
                {
                    Id = x.Id,
                    JobTitle = x.JobTitle,
                    CompanyName = x.CompanyName,
                    FromDate = x.FromDate,
                    ToDate = x.ToDate,
                    Salary = x.Salary
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<ExperienceDto>> GetById(int id)
        {
            var result = new ServiceResult<ExperienceDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new ExperienceDto
            {
                Id = data.Id,
                JobTitle = data.JobTitle,
                CompanyName = data.CompanyName,
                FromDate = data.FromDate,
                ToDate = data.ToDate,
                Salary = data.Salary
            };

            return result;
        }
    }
}
