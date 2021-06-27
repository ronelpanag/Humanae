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
    public class ExperienceService : IExperienceService
    {
        private readonly IRepository<Experience> _repository;
        private readonly IRepository<ApplicantExperience> _repository1;

        public ExperienceService(IRepository<Experience> repository,
            IRepository<ApplicantExperience> repository1)
        {
            _repository = repository;
            _repository1 = repository1;
        }

        public async Task<ServiceResult> Create(ExperienceParameter parameter)
        {
            var result = new ServiceResult();

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

                var assignationData = new ApplicantExperience
                {
                    ApplicantId = parameter.ApplicantId,
                    ExperienceId = data.Id
                };

                await _repository1.AddAsync(assignationData);
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

        public async Task<ServiceResult> Edit(ExperienceParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.CompanyName = parameter.CompanyName;
                modelToUpdate.JobTitle = parameter.JobTitle;
                modelToUpdate.Salary = parameter.Salary;
                modelToUpdate.FromDate = parameter.FromDate;
                modelToUpdate.ToDate = parameter.ToDate;

                await _repository.UpdateAsync(modelToUpdate);


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

        public async Task<ServiceResult<List<ExperienceDto>>> GetApplicantExperiences(int applicantId)
        {
            var result = new ServiceResult<List<ExperienceDto>>();

            var data = await _repository1.Entity()
                .Where(x => x.ApplicantId == applicantId)
                .Select(x => new ExperienceDto
                {
                    Id = x.ExperienceId,
                    JobTitle = x.Experience.JobTitle,
                    CompanyName = x.Experience.CompanyName,
                    FromDate = x.Experience.FromDate,
                    ToDate = x.Experience.ToDate,
                    Salary = x.Experience.Salary
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }
    }
}
