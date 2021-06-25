using System.ComponentModel.DataAnnotations;

namespace Humanae.DomainGlobal
{
    public enum RiskLevel
    {
        [Display(Name = "Bajo")]
        Low = 1,
        [Display(Name = "Medio")]
        Mid,
        [Display(Name = "Alto")]
        High
    }
}
