using System;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Experience
    {
        public int Id { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        [Required]
        public decimal Salary { get; set; }
    }
}
