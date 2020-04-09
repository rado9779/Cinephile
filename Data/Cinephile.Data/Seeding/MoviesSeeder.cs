namespace Cinephile.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Models;

    public class MoviesSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Movies.Any())
            {
                return;
            }

            var movies = new List<(string Title, int Year, string Genre, string Description, string CreatedBy, string Producer, string ImageUrl)>
            {
               ("John Wick", 2014, "Action", "Ex-hitman John Wick comes.","Chad Stahelski","Chad Stahelski", "https://upload.wikimedia.org/wikipedia/en/9/98/John_Wick_TeaserPoster.jpg"),
               ("Joker", 2019, "Crime", "During the 1980s, a failed stand-up comedian is driven.", "Todd Phillips", "Scott Silver", "https://upload.wikimedia.org/wikipedia/en/e/e1/Joker_%282019_film%29_poster.jpg"),
               ("Star Wars", 1977, "Action", "Princess Leia is captured and held hostage by the evil Imperial","George Lucas","	George Lucas", "https://upload.wikimedia.org/wikipedia/commons/thumb/c/ce/Star_wars2.svg/330px-Star_wars2.svg.png"),
               ("Inception", 2010, "Action", "Cobb, a skilled thief who commits corporate espionage","Christopher Nolan","Christopher Nolan", "https://upload.wikimedia.org/wikipedia/en/2/2e/Inception_%282010%29_theatrical_poster.jpg"),
            };

            foreach (var movie in movies)
            {
                await dbContext.Movies.AddAsync(new Movie
                {
                    Title = movie.Title,
                    Year = movie.Year,
                    Genre = movie.Genre,
                    Description = movie.Description,
                    CreatedBy = movie.CreatedBy,
                    Producer = movie.Producer,
                    ImageUrl = movie.ImageUrl,
                });
            }
        }
    }
}
