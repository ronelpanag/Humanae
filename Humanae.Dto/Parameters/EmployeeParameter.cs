using System;

namespace Humanae.Dto.Parameters
{
    public class EmployeeParameter
    {
        public int Id { get; set; }
        public string Identification { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime StartDate { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public decimal MonthlySalary { get; set; }
    }
}
