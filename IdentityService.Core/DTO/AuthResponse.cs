
namespace IdentityService.Core.DTO
{
    
    public record AuthResponse(Guid UserID, string? UserName, string? Email, string? Gender, string? Token,
       bool Success )
    {
        public AuthResponse() : this(default, default, default, default, default, default)
        {

        }

    }
    
}
