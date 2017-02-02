using Microsoft.AspNet.Identity.EntityFramework;
using MVCSample.Models;

namespace MVCSample
{
    public class ApplicationUserStore : UserStore<ApplicationUser>
    {
        public ApplicationUserStore(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}