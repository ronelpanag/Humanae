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
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _repository;
        private readonly IRepository<ApplicantSkill> _applicantSkillRepository;

        public SkillService(IRepository<Skill> repository,
            IRepository<ApplicantSkill> applicantSkillRepository)
        {
            _repository = repository;
            _applicantSkillRepository = applicantSkillRepository;
        }

        public async Task<ServiceResult<IEnumerable<SkillDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<SkillDto>>();

            var data = await _repository.GetAllAsync();

            result.Data = data
                .Select(x => new SkillDto
                {
                    Id = x.Id,
                    Description = x.Description,
                    IsActive = x.IsActive
                })
                .ToList();

            return result;
        }

        public async Task<ServiceResult<SkillDto>> GetById(int id)
        {
            var result = new ServiceResult<SkillDto>();

            var data = await _repository.FirstOrDefaultAsync(x => x.Id == id);

            result.Data = new SkillDto
            {
                Id = data.Id,
                Description = data.Description,
                IsActive = data.IsActive
            };

            return result;
        }

        public async Task<ServiceResult> Create(SkillParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var data = new Skill
                {
                    Description = parameter.Description
                };

                await _repository.AddAsync(data);

                var assignationData = new ApplicantSkill
                {
                    ApplicantId = parameter.ApplicantId,
                    SkillId = data.Id
                };

                await _applicantSkillRepository.AddAsync(assignationData);
            }
            catch(Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Edit(SkillParameter parameter)
        {
            var result = new ServiceResult();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Description = parameter.Description;

                await _repository.UpdateAsync(modelToUpdate);

            }
            catch(Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            var result = new ServiceResult();

            var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id && !x.IsActive);

            if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.Description))
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

        public async Task<ServiceResult<List<SkillDto>>> GetApplicantSkills(int applicantId)
        {
            var result = new ServiceResult<List<SkillDto>>();

            var data = await _applicantSkillRepository.Entity()
                .Where(x => x.ApplicantId == applicantId)
                .Select(x => new SkillDto
                {
                    Id = x.SkillId,
                    Description = x.Skill.Description,
                    IsActive = x.Skill.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }
    }
}
