namespace Humanae.Domain.Entities
{
    public class ApplicantTraining
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int TrainingId { get; set; }
        public Training Training { get; set; }
    }
}
