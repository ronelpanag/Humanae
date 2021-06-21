﻿using Humanae.Contracts;
using Humanae.DomainGlobal;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Position : IDeletableEntity
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public RiskLevel RiskLevel { get; set; }
        [Required]
        public decimal MinSalary { get; set; }
        [Required]
        public decimal MaxSalary { get; set; }
        public bool IsActive { get; set; } = true;
    }
}