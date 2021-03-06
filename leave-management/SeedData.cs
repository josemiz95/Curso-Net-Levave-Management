using leave_management.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management
{
    public static class SeedData
    {
        public static void Seed(UserManager<Employee> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedUsers(UserManager<Employee> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var user = new Employee()
                {
                    UserName = "admin@localhost",
                    Email = "admin@localhost",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
            if (userManager.FindByNameAsync("employee").Result == null)
            {
                var user = new Employee()
                {
                    UserName = "employee@localhost",
                    Email = "employee@localhost",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(user, "Password123!").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Employee").Wait();
                }
            }
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var role = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(role).Result;
            }
        }
    }
}
