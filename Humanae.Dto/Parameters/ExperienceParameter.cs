using System;

namespace Humanae.Dto.Parameters
{
    public class ExperienceParameter
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public decimal Salary { get; set; }
        public string JobTitle { get; set; }
    }
}
