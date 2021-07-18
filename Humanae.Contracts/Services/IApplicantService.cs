using Humanae.DomainGlobal;
using Humanae.Dto;
using Humanae.Dto.Parameters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Humanae.Contracts.Services
{
    public interface IApplicantService
    {
        Task<ServiceResult<IEnumerable<ApplicantDto>>> GetAll();
        Task<ServiceResult<ApplicantDto>> GetById(int id);
        Task<ServiceResult> Create(ApplicantParameter parameter);
        Task<ServiceResult> Edit(ApplicantParameter parameter);
        Task<ServiceResult> Delete(DeleteParameter parameter);
        Task<ServiceResult> ConvertToEmployee(int applicantId, decimal salary, DateTime startdate);
    }
}
