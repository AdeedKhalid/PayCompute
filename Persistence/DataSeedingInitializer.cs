using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DataSeedingInitializer
    {
        public enum Roles
        {
            Admin,
            Manager,
            Staff
        }

        public static async Task UserAndRoleSeedAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            //Create Roles
            foreach (Roles role in Enum.GetValues(typeof(Roles)))
            {
                var roleExist = await roleManager.RoleExistsAsync(role.ToString());
                if (!roleExist)
                {
                    IdentityResult result = await roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }

            //Create Admin User
            if (userManager.FindByEmailAsync("admin@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "admin@gmail.com",
                    Email = "admin@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Admin1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Admin.ToString()).Wait();
                }
            }

            //Create Manager User
            if (userManager.FindByEmailAsync("manager@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "manager@gmail.com",
                    Email = "manager@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Manager1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Manager.ToString()).Wait();
                }
            }

            //Create Staff User
            if (userManager.FindByEmailAsync("staff@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "staff@gmail.com",
                    Email = "staff@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "Staff1").Result;
                if (identityResult.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Staff.ToString()).Wait();
                }
            }

            //Create No Role User
            if (userManager.FindByEmailAsync("none@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = "none@gmail.com",
                    Email = "none@gmail.com"
                };
                IdentityResult identityResult = userManager.CreateAsync(user, "None1").Result;
                //No Role assigned
            }
        }
    }
}
