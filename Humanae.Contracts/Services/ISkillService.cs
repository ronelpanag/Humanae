using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface ISkillService
    {
        Task<ServiceResult<IEnumerable<SkillDto>>> GetAll();
        Task<ServiceResult<SkillDto>> GetById(int id);
        Task<ServiceResult> Create(SkillParameter parameter);
        Task<ServiceResult> Edit(SkillParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
        Task<ServiceResult<List<SkillDto>>> GetApplicantSkills(int applicantId);
    }
}
