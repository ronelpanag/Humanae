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
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;

        public EmployeeService(IRepository<Employee> repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResult<EmployeeDto>> Create(EmployeeParameter parameter)
        {
            var result = new ServiceResult<EmployeeDto>();

            var data = new Employee
            {
                FirstName = parameter.FirstName,
                LastName = parameter.LastName,
                Identification = parameter.Identification,
                PositionId = parameter.PositionId,
                StartDate = parameter.StartDate,
                ApplicantId = parameter.ApplicantId,
                MonthlySalary = parameter.MonthlySalary
            };

            try
            {
                await _repository.AddAsync(data);

                var model = await GetById(data.Id);

                result.Data = model.Data;
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult> Delete(DeleteParameter parameter)
        {
            var result = new ServiceResult();

            var modelToDelete = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

            if (!string.Equals(parameter.ConfirmationMessage, modelToDelete.FirstName))
            {
                result.AddErrorMessage("Mensaje de confirmación inválido.");
                return result;
            }

            modelToDelete.IsActive = false;

            try
            {
                await _repository.UpdateAsync(modelToDelete);
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult<EmployeeDto>> Edit(EmployeeParameter parameter)
        {
            var result = new ServiceResult<EmployeeDto>();

            try
            {
                var modelToUpdate = await _repository.FirstOrDefaultAsync(x => x.Id == parameter.Id);

                modelToUpdate.FirstName = parameter.FirstName;
                modelToUpdate.LastName = parameter.LastName;
                modelToUpdate.Identification = parameter.Identification;
                modelToUpdate.PositionId = parameter.PositionId;
                modelToUpdate.StartDate = parameter.StartDate;
                modelToUpdate.ApplicantId = parameter.ApplicantId;
                modelToUpdate.MonthlySalary = parameter.MonthlySalary;

                await _repository.UpdateAsync(modelToUpdate);

                var model = await GetById(modelToUpdate.Id);

                result.Data = model.Data;
            }
            catch (Exception e)
            {
                result.AddErrorMessage(e);
            }

            return result;
        }

        public async Task<ServiceResult<IEnumerable<EmployeeDto>>> GetAll()
        {
            var result = new ServiceResult<IEnumerable<EmployeeDto>>();

            var data = await _repository.Entity()
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    PositionId = x.PositionId,
                    Position = x.Position.Name,
                    DepartmentId = x.Position.DepartmentId,
                    Department = x.Position.Department.Name,
                    MonthlySalary = x.MonthlySalary,
                    StartDate = x.StartDate,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            result.Data = data;

            return result;
        }

        public async Task<ServiceResult<EmployeeDto>> GetById(int id)
        {
            var result = new ServiceResult<EmployeeDto>();

            var data = await _repository.Entity()
                .Select(x => new EmployeeDto
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Identification = x.Identification,
                    PositionId = x.PositionId,
                    Position = x.Position.Name,
                    DepartmentId = x.Position.DepartmentId,
                    Department = x.Position.Department.Name,
                    MonthlySalary = x.MonthlySalary,
                    StartDate = x.StartDate,
                    IsActive = x.IsActive
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            result.Data = data;

            return result;
        }
    }
}
