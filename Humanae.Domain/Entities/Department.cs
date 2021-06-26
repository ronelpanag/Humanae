using Humanae.Contracts;
using Humanae.Dto;
using System;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Department : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
