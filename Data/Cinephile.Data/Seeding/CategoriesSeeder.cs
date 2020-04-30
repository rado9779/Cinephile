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

            var categories = new List<(string Name, string ImageUrl, string Title, string Description)>
            {
                ("Funny", "/StaticFiles/bring.png","Funny","Funny"),
                ("Actors", "/StaticFiles/actor.png","Actors","Actors"),
                ("Meetings", "/StaticFiles/teamwork.png","Meetings","Meetings"),
                ("Movies", "/StaticFiles/cinema.png","Movies","Movies"),
                ("TV-Series", "/StaticFiles/television.png","TV-Series","TV-Series"),
                ("News", "/StaticFiles/newspaper.png","News","News"),
            };

            foreach (var category in categories)
            {
                await dbContext.Categories.AddAsync(new Category
                {
                    Name = category.Name,
                    ImageUrl = category.ImageUrl,
                    Title = category.Title,
                    Description = category.Description,
                });
            }
        }
    }
}
