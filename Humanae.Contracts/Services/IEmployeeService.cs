using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IEmployeeService
    {
        Task<ServiceResult<IEnumerable<EmployeeDto>>> GetAll();
        Task<ServiceResult<EmployeeDto>> GetById(int id);
        Task<ServiceResult> Create(EmployeeParameter parameter);
        Task<ServiceResult> Edit(EmployeeParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
    }
}
