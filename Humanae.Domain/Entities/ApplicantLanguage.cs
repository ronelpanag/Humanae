namespace Humanae.Domain.Entities
{
    public class ApplicantLanguage
    {
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int LanguageId { get; set; }
        public Language Language { get; set; }
    }
}
