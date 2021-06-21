using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface ITrainingService
    {
        Task<ServiceResult<IEnumerable<TrainingDto>>> GetAll();
        Task<ServiceResult<TrainingDto>> GetById(int id);
        Task<ServiceResult<TrainingDto>> Create(TrainingParameter parameter);
        Task<ServiceResult<TrainingDto>> Edit(TrainingParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
