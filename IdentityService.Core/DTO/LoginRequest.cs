
namespace IdentityService.Core.DTO
{
    public record LoginRequest ( string? Email, string? Password)
    {
        public LoginRequest() : this(default, default)
        {
            // This constructor is used for deserialization or when no parameters are provided.
        }
    }
   
}
