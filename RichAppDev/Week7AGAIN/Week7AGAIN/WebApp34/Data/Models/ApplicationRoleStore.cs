using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApp34.Data.Models;

namespace WebApp34.Data.Models
{

    public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, string>
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }

        // Additional custom logic if needed
    }

}
