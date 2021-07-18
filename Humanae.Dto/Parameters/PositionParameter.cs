using Humanae.DomainGlobal;

namespace Humanae.Dto.Parameters
{
    public class PositionParameter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string RiskLevel { get; set; }
        public decimal MinSalary { get; set; }
        public decimal MaxSalary { get; set; }
        public int DepartmentId { get; set; }
    }
}
