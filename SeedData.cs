using Microsoft.AspNetCore.Identity;
using ONS_Hardware_Web_Application.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ONS_Hardware_Web_Application
{
    public static class SeedData
    {
        public static void Seed (UserManager<Employee> userManager,
            RoleManager<IdentityRole> rolemanager)
            {
            SeedRoles(rolemanager);
            SeedUsers(userManager);
            }
        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync("admin@localhost.com").Result == null)  // Chaecking if the is any user with the name admin
            {
                var user = new Employee  //if nothing comes back (null)... we create an object called "Employee"       This Line is questionable within 
                {
                    UserName = "admin@localhost.com",             //passing in the user name and Email
                    Email = "admin@localhost.com"
                };
                var result = userManager.CreateAsync(user, "P@ssword1").Result;
                if (result.Succeeded)    // if result succeeded then we need to assign this user to a role
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }

        }

        private static void SeedRoles(RoleManager<IdentityRole> rolemanager)
        {
            if (!rolemanager.RoleExistsAsync("Administrator").Result) // If it doesn't exist... and the ".Result" returns a boolean
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"      //Creating a new role object called admnistrator
                };
                var result = rolemanager.CreateAsync(role).Result;
            }

            if (!rolemanager.RoleExistsAsync("Employee").Result) // If it doesn't exist... and the ".Result" returns a boolean
            {
                var role = new IdentityRole
                {
                    Name = "Employee"      //Creating a new role object called admnistrator
                };
                var result = rolemanager.CreateAsync(role).Result;
            }
        }
    }
}
