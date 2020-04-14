namespace Cinephile.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Categories.Any())
            {
                return;
            }

            var categories = new List<(string Name, string ImageUrl)>
            {
                ("Funny", "/StaticFiles/bring.png"),
                ("Actors", "/StaticFiles/actor.png"),
                ("Meetings", "/StaticFiles/teamwork.png"),
                ("Movies", "/StaticFiles/cinema.png"),
                ("TV-Series", "/StaticFiles/television.png"),
                ("News", "/StaticFiles/newspaper.png"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    ImageUrl = category.ImageUrl,
                });
            }
        }
    }
}
