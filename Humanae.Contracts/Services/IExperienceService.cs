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
        Task<ServiceResult> Create(ExperienceParameter parameter);
        Task<ServiceResult> Edit(ExperienceParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
        Task<ServiceResult<List<ExperienceDto>>> GetApplicantExperiences(int applicantId);
    }
}
