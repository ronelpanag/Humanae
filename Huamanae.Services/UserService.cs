using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto.Parameters;
using System.Threading.Tasks;

namespace Humanae.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _repository;

        public UserService(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult> Login(AuthenticateParameter parameter)
        {
            var result = new ServiceResult();

            var userExists = await _repository.Exists(x => x.Username == parameter.Username && x.Password == parameter.Password);

            if (!userExists)
            {
                result.AddErrorMessage("Usuario y/o contraseña incorrectos.");
                return result;
            }

            result.AddMessage("Inicio de sesión exitoso.");
            return result;
        }
    }
}
