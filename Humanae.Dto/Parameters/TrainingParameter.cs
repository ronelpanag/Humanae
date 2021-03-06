using System;

namespace Humanae.Dto.Parameters
{
    public class TrainingParameter
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Level { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Institution { get; set; }
        public int ApplicantId { get; set; }
    }
}
