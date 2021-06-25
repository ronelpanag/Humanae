using Humanae.Contracts.Repositories;
using Humanae.Contracts.Services;
using Humanae.Domain.Entities;
using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public Task<ServiceResult<EmployeeDto>> Create(EmployeeParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<EmployeeDto>> Edit(EmployeeParameter parameter)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<EmployeeDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
