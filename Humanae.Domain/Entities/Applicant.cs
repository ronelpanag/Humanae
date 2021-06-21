using Humanae.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Applicant : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Identification { get; set; }
        [Required]
        public int AppliedPositionId { get; set; }
        public Position AppliedPosition { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        [Required]
        public string RecommendedBy { get; set; } = "N/A";
        public bool IsChosen { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
