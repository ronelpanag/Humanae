using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IExperienceService
    {
        Task<ServiceResult<IEnumerable<ExperienceDto>>> GetAll();
        Task<ServiceResult<ExperienceDto>> GetById(int id);
        Task<ServiceResult<ExperienceDto>> Create(ExperienceParameter parameter);
        Task<ServiceResult<ExperienceDto>> Edit(ExperienceParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
