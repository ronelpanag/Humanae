using Humanae.Contracts;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Language : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
