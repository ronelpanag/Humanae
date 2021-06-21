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
    public class TrainingService : ITrainingService
    {
        private readonly IRepository<Training> _repository;

        public TrainingService(IRepository<Training> repository)
        {
            _repository = repository;
        }

        public Task<ServiceResult<TrainingDto>> Create(TrainingParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<TrainingDto>> Edit(TrainingParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<TrainingDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<TrainingDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
