using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using E7GeZlY.Models;

[assembly: OwinStartupAttribute(typeof(E7GeZlY.Startup))]
namespace E7GeZlY
{
    public partial class Startup
    {
        private ApplicationDbContext db = new ApplicationDbContext(); 
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateDefaultAdmins();
        }

        public void CreateDefaultAdmins()
        {
            var rolemanger = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var usermanager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
            IdentityRole role = new IdentityRole();
            if (!rolemanger.RoleExists("Administrator"))
            {
                role.Id = "10";
                role.Name = "Administrator";
                rolemanger.Create(role);
                ApplicationUser user = new ApplicationUser();
                user.UserName = "Mahmoud@yahoo.com";
                user.FirstName = "Mahmoud";
                user.LastName = "Ibrahim";
                user.Email = "Mahmoud@yahoo.com";
                var Check = usermanager.Create(user, "Pa$$word123");
                if (Check.Succeeded)
                {
                    usermanager.AddToRole(user.Id, "Administrator");
                }
            }
        }
    }
}
