using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
