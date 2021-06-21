using System;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Domain.Entities
{
    public class Training
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Level { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public string Institution { get; set; }
    }
}
