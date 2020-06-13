using WebLabs_Klempach.DAL.Data;
using WebLabs_Klempach.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

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

            if (!context.LootCategories.Any())
            {
                context.LootCategories.AddRange(new List<LootCategory>
                {
                    new LootCategory {LootCategoryName = "Weapon"},
                    new LootCategory {LootCategoryName = "Suits"},
                    new LootCategory {LootCategoryName = "Enhancers"},
                    new LootCategory {LootCategoryName = "Snacks"}
                });
                await context.SaveChangesAsync();
            }

            if (!context.Loot.Any())
            {
                context.Loot.AddRange(new List<Loot>
                {
                    new Loot
                    {
                        LootCategoryId = 1,
                        LootName = "Hammer",
                        LootDescription = "A powerful hammer that chooses the one who deserves it",
                        LootPrice = 200,
                        LootImageName = "hammer.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 1,
                        LootName = "Shield",
                        LootDescription = "A light and strong shield",
                        LootPrice = 50,
                        LootImageName = "shield.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 2,
                        LootName = "Iron Man Suit",
                        LootDescription = "Protection suit to make you a real superhero. Sizes XS, S, M, L, XL",
                        LootPrice = 100,
                        LootImageName = "iron-man-suit.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 2,
                        LootName = "Spider Man Suit",
                        LootDescription = "Soft and comfy. Hypoallergenic fabric. Has web throwers installed. Sizes XS, S, M, L, XL",
                        LootPrice = 100,
                        LootImageName = "spider-man-suit.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 1,
                        LootName = "Batarangs",
                        LootDescription = "Sharp and deadly. Have ergonomic design. Sizes S, M, L",
                        LootPrice = 100,
                        LootImageName = "batarangs.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 3,
                        LootName = "X-Ray vision",
                        LootDescription = "Allows you to see through living beings and objects.",
                        LootPrice = 70,
                        LootImageName = "x-ray-vision.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 3,
                        LootName = "Wolverine claws",
                        LootDescription = "Installed in arms. Materials: stainless steel/ bone",
                        LootPrice = 50,
                        LootImageName = "wolverine-claws.jpg",
                        LootImageMimeType = ".jpg"
                    },
                    new Loot
                    {
                        LootCategoryId = 4,
                        LootName = "Shawarma",
                        LootDescription = "The best snack after saving the world",
                        LootPrice = 60,
                        LootImageName = "shawarma.jpg",
                        LootImageMimeType = ".jpg"
                    },
                });
                
                await context.SaveChangesAsync();
            }

        }
    }
}
