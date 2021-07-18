using Humanae.DomainGlobal;

namespace Humanae.Dto.Parameters
{
    public class CreateUserParameter
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int EmployeeId { get; set; }
        public Role Role { get; set; }
    }
}
