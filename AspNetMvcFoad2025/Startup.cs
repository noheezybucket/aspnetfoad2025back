﻿using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Owin;
using AspNetMvcFoad2025.Models;

[assembly: OwinStartupAttribute(typeof(AspNetMvcFoad2025.Startup))]
namespace AspNetMvcFoad2025
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            // In Startup iam creating first Admin Role and creating a default Admin User
 if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website

                 var user = new ApplicationUser();
                user.UserName = "AdmainColis";
                user.Email = "admincolis@yopmail.com";

                string userPWD = "P@sse1234";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");


                }
                // creating Creating Livreur role
                if (!roleManager.RoleExists("Livreur"))
                {
                    var livreurRole = new IdentityRole { Name = "Livreur" };
                    roleManager.Create(livreurRole);
                }

                if (!roleManager.RoleExists("Client"))
                {
                    var clientRole = new IdentityRole { Name = "Client" };
                    roleManager.Create(clientRole);
                }
            }
        }
        
     }
}
