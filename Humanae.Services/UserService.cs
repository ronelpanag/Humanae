using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

            try
            {
                var userExists = await _repository
                .ExistsAsync(x => x.Username == parameter.Username &&
                             x.Password == parameter.Password);

                if (!userExists)
                {
                    result.AddErrorMessage("Usuario y/o contraseña incorrectos.");
                    return result;
                }

                result.AddMessage("Inicio de sesión exitoso.");
            }
            catch (Exception ex)
            {
                result.AddErrorMessage(ex);
            }

            return result;
        }

        public async Task<ServiceResult<List<UserDto>>> GetAll()
        {
            var result = new ServiceResult<List<UserDto>>();

            var data = await _repository.Entity()
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Employee = x.Employee.FirstName + x.Employee.LastName,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }
    }
}
