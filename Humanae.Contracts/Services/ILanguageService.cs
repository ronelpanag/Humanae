using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface ILanguageService
    {
        Task<ServiceResult<IEnumerable<LanguageDto>>> GetAll();
        Task<ServiceResult<LanguageDto>> GetById(int id);
        Task<ServiceResult<LanguageDto>> Create(LanguageParameter parameter);
        Task<ServiceResult<LanguageDto>> Edit(LanguageParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
