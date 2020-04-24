namespace Cinephile.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Cinephile.Data.Models;

    public class GenresSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Genres.Any())
            {
                return;
            }

            var genres = new List<string>()
            {
               "Action",  "Adventure", "Comedy", "Crime", "Drama", "Fantasy", "Historical", "Horror", "Social",
            };

            foreach (var genre in genres)
            {
                await dbContext.Genres.AddAsync(new Genre
                {
                    Name = genre,
                });
            }
        }
    }
}
