using Humanae.Contracts;
using System;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Employee : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Identification { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        public int PositionId { get; set; }
        public Position Position { get; set; }
        [Required]
        public decimal MonthlySalary { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
