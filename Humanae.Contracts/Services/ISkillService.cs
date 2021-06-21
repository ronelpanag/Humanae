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
        Task<ServiceResult<SkillDto>> Create(SkillParameter parameter);
        Task<ServiceResult<SkillDto>> Edit(SkillParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
