using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IPositionService
    {
        Task<ServiceResult<IEnumerable<PositionDto>>> GetAll();
        Task<ServiceResult<PositionDto>> GetById(int id);
        Task<ServiceResult> Create(PositionParameter parameter);
        Task<ServiceResult> Edit(PositionParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
