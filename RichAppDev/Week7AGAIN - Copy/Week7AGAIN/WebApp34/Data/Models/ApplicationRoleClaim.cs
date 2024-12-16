using Microsoft.AspNetCore.Identity;

namespace WebApp34.Data.Models
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
