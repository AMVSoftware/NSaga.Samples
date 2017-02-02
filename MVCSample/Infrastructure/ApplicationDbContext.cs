using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MVCSample.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            
        }

        public IDbSet<Product> Products { get; set; }
    }
}