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
    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> _repository;

        public SkillService(IRepository<Skill> repository)
        {
            _repository = repository;
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

        public async Task<ServiceResult<SkillDto>> Create(SkillParameter parameter)
        {
            var result = new ServiceResult<SkillDto>();

            try
            {
                var data = new Skill
                {
                    Description = parameter.Description
                };

                await _repository.AddAsync(data);

                var model = await GetById(data.Id);

                result.Data = model.Data;
            }
            catch(Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult<SkillDto>> Edit(SkillParameter parameter)
        {
            var result = new ServiceResult<SkillDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.Description = parameter.Description;

                await _repository.UpdateAsync(modelToUpdate);

                var model = await GetById(modelToUpdate.Id);

                result.Data = model.Data;
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
    }
}
