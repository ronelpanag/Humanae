using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
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

        public Task<ServiceResult<ExperienceDto>> Create(ExperienceParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ExperienceDto>> Edit(ExperienceParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<ExperienceDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<ExperienceDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
