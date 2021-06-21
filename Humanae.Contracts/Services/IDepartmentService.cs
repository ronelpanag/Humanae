using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IDepartmentService
    {
        Task<ServiceResult<IEnumerable<DepartmentDto>>> GetAll();
        Task<ServiceResult<DepartmentDto>> GetById(int id);
        Task<ServiceResult<DepartmentDto>> Create(DepartmentParameter parameter);
        Task<ServiceResult<DepartmentDto>> Edit(DepartmentParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
