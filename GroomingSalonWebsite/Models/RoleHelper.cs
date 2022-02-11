using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Had to throw this using in because otherwise the GetService was creating issues.
using Microsoft.Extensions.DependencyInjection;

namespace GroomingSalonWebsite.Models
{
#nullable disable
    public static class RoleHelper
    {
        public const string User = "User";
        public const string Admin = "Admin";

        public static async Task CreateRoles(IServiceProvider provider, params string[] roles)
        {
            RoleManager<IdentityRole> roleManager = provider.GetService<RoleManager<IdentityRole>>();

            foreach(string role in roles)
            {
                bool doesRoleExist = await roleManager.RoleExistsAsync(role);
                if(!doesRoleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }
        }

        //Removed because the class is not needed and creates a flaw by providing a free admin class
        /*public static async Task CreateDefaultUser(IServiceProvider provider, string role)
        {
            var userManager = provider.GetService<UserManager<IdentityUser>>();

            //If no users are present, make the default user
            int numUsers = (await userManager.GetUsersInRoleAsync(role)).Count;
            if (numUsers == 0)
            {
                var defaultUser = new IdentityUser()
                {
                    Email = "user@user.com",
                    UserName = "Admin"
                };

                await userManager.CreateAsync(defaultUser, "Password1!");

                await userManager.AddToRoleAsync(defaultUser, role);
            }
        }*/
    }
}
