using Humanae.DomainGlobal;
using Humanae.Dto.Parameters;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IUserService
    {
        Task<ServiceResult> Login(AuthenticateParameter parameter);
    }
}
