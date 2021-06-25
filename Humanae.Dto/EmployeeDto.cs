using System;

namespace Humanae.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int PositionId { get; set; }
        public string Identification { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public decimal MonthlySalary { get; set; }
        public bool IsActive { get; set; }
    }
}
