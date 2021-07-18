namespace Humanae.Domain.Entities
{
    public class ApplicantExperience
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int ExperienceId { get; set; }
        public Experience Experience { get; set; }
    }
}
