using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace CodingCraftHOMod1Ex2Scaffolding.Models
{
    public class CodingCraftHOMod1Ex2ScaffoldingContext : IdentityDbContext<ApplicationUser>
    {
        public CodingCraftHOMod1Ex2ScaffoldingContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static CodingCraftHOMod1Ex2ScaffoldingContext Create()
        {
            return new CodingCraftHOMod1Ex2ScaffoldingContext();
        }

        public DbSet<CodingCraftHOMod1Ex2Scaffolding.Models.Produto> Produtos { get; set; }
    }
}