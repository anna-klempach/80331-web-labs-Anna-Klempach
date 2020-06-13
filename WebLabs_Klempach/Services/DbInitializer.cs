using WebLabs_Klempach.DAL.Data;
using WebLabs_Klempach.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLabs_Klempach.Services
{
    public class DbInitializer
    {
        public static async Task Seed(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();
            if (!context.Roles.Any())
            {
                var roleAdmin = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin"
                };
                var result = await roleManager.CreateAsync(roleAdmin);
            }
            if (!context.Users.Any())
            {
                var user = new ApplicationUser
                {
                    Email = "peter.parker@gmail.com",
                    UserName = "peter.parker@gmail.com"
                };
                await userManager.CreateAsync(user, "IamSpiderman123");
                var admin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com"
                };
                await userManager.CreateAsync(admin, "IamAdmin123");

                admin = await userManager.FindByEmailAsync("admin@gmail.com");
                await userManager.AddToRoleAsync(admin, "admin");
            }
        }
    }
}
