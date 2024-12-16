using Microsoft.AspNetCore.Identity;

namespace WebApp34.Data.Models
{
    public class ApplicationUserClaim : IdentityUserClaim<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}

