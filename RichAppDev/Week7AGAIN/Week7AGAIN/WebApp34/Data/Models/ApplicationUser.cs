using Microsoft.AspNetCore.Identity;

namespace WebApp34.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        //public virtual ICollection<IdentityUser<string>> User { get; set; }
        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }
        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }
        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
