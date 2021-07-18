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
using System.Security.Cryptography;
using System.Text;
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

        public async Task<ServiceResult<UserDto>> Login(AuthenticateParameter parameter)
        {
            var result = new ServiceResult<UserDto>();

            try
            {
                var encryptedPassword = GetMD5Hash(parameter.Password);

                var data = await _repository.Entity()
                    .Where(x => x.Username == parameter.Username &&
                                x.Password == encryptedPassword &&
                                x.IsActive)
                    .Select(x => new UserDto
                    {
                        Id = x.Id,
                        Username = x.Username,
                        Email = x.Email,
                        Employee = x.Employee.FirstName + " " + x.Employee.LastName,
                        IsActive = x.IsActive,
                        Role = x.Role
                    })
                    .FirstOrDefaultAsync();

                if (data == null)
                {
                    result.AddErrorMessage("Usuario y/o contraseña incorrectos.");
                    return result;
                }

                result.Data = data;

                result.AddMessage("Inicio de sesión exitoso.");
            }
            catch (Exception ex)
            {
                result.AddErrorMessage(ex);
            }

            return result;
        }

        public async Task<ServiceResult> Create(CreateUserParameter parameter)
        {
            var result = new ServiceResult();

            var encryptedPassword = GetMD5Hash(parameter.Password);

            var user = new User
            {
                Username = parameter.Username,
                Password = encryptedPassword,
                Email = parameter.Email,
                EmployeeId = parameter.EmployeeId,
                Role = parameter.Role
            };

            try
            {
                await _repository.AddAsync(user);
            }
            catch(Exception ex)
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
                    IsActive = x.IsActive,
                    Role = x.Role
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult<List<UserDto>>> GetActives()
        {
            var result = new ServiceResult<List<UserDto>>();

            var data = await _repository.Entity()
                .Where(x => x.IsActive)
                .Select(x => new UserDto
                {
                    Id = x.Id,
                    Username = x.Username,
                    Email = x.Email,
                    Employee = x.Employee.FirstName + x.Employee.LastName,
                    IsActive = x.IsActive,
                    Role = x.Role
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        private string GetMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
