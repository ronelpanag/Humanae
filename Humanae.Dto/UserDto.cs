using Humanae.DomainGlobal;
using System.ComponentModel.DataAnnotations;

namespace Humanae.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Employee { get; set; }
        public bool IsActive { get; set; }
        public Role Role { get; set; }
    }
}
