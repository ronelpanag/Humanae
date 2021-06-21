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
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> _repository;

        public LanguageService(IRepository<Language> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<LanguageDto>> Create(LanguageParameter parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<LanguageDto>> Edit(LanguageParameter parameter)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<IEnumerable<LanguageDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResult<LanguageDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
