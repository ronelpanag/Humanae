using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IUserService
    {
        Task<ServiceResult<UserDto>> Login(AuthenticateParameter parameter);
        Task<ServiceResult> Create(CreateUserParameter parameter);
        Task<ServiceResult<List<UserDto>>> GetAll();
    }
}
