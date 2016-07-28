using CodingCraftHOMod1Ex1EF.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IdentitySample.Models
{
    public class ApplicationUserRole : IdentityUserRole<int> { }
    public class ApplicationUserLogin : IdentityUserLogin<int> { }
    public class ApplicationUserClain : IdentityUserClaim<int> { }
    public class ApplicationRole : IdentityRole<int, ApplicationUserRole> { }
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClain>
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClain>
    {
        //public ApplicationDbContext()
        //    : base("DefaultConnection", throwIfV1Schema: false)
        //{
        //}

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            // Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.Produto> Produtos { get; set; }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.Fornecedor> Fornecedores { get; set; }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.ProdutoFornecedor> ProdutosFornecedores { get; set; }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.Cliente> Clientes { get; set; }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.MovimentacaoCliente> MovimentacaoClientes { get; set; }

        public System.Data.Entity.DbSet<CodingCraftHOMod1Ex1EF.Models.MovimentacaoFornecedor> MovimentacaoFornecedors { get; set; }
    }
}