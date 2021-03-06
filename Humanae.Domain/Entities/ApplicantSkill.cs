namespace Humanae.Domain.Entities
{
    public class ApplicantSkill
    {
        public int Id { get; set; }
        public int ApplicantId { get; set; }
        public Applicant Applicant { get; set; }
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}
