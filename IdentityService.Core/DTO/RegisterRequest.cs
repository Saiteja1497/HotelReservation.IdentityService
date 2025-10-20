
namespace IdentityService.Core.DTO
{
    public record RegisterRequest(string? UserName, string? Password, string? Email, GenderOptions Gender)
    {
        public RegisterRequest() : this(default, default, default, default)
        {
            
        }
    }
}

