namespace Humanae.Dto.Parameters
{
    public class ApplicantParameter
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public int AppliedPositionId { get; set; }
        public int DepartmentId { get; set; }
        public string RecommendedBy { get; set; } = "N/A";
    }
}
