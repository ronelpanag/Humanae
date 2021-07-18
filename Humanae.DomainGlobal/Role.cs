using System.ComponentModel.DataAnnotations;

namespace Humanae.DomainGlobal
{
    public enum Role
    {
        [Display(Name = "Administrador")]
        Admin = 1,
        [Display(Name = "Analista de Recursos Humanos")]
        HR,
        [Display(Name = "Usuario")]
        User
    }
}
