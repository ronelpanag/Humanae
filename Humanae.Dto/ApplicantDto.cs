namespace Humanae.Dto
{
    public class ApplicantDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string AppliedPosition { get; set; }
        public string Department { get; set; }
        public string RecommendedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
