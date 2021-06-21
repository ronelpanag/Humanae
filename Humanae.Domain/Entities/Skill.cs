using Humanae.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Skill : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
