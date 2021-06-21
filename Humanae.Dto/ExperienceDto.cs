using System;

namespace Humanae.Dto
{
    public class ExperienceDto
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal Salary { get; set; }
    }
}
