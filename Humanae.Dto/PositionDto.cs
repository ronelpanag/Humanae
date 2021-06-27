using Humanae.DomainGlobal;

namespace Humanae.Dto
{
    public class PositionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RiskLevel { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public string Department { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
