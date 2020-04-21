namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Movies;

    public class MoviesService : IMoviesService
    {
        private readonly IDeletableEntityRepository<Movie> moviesRepository;

        public MoviesService(IDeletableEntityRepository<Movie> moviesRepository)
        {
            this.moviesRepository = moviesRepository;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Movie> query =
                 this.moviesRepository.All().OrderBy(x => x.Title);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task Create(MovieCreateModel input)
        {
            var movie = new Movie()
            {
                ImageUrl = input.ImageUrl,
                Title = input.Title,
                Year = input.Year,
                Description = input.Description,
                HomePageLink = input.HomePageLink,
                IMDBLink = input.IMDBLink,
                TrailerLink = input.TrailerLink,
                FacebookLink = input.FacebookLink,
                Creater = input.Creater,
                Producer = input.Producer,
                Country = input.Country,
            };

            await this.moviesRepository.AddAsync(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public T GetByTitle<T>(string title)
        {
            var movie = this.moviesRepository
               .All()
               .Where(x => x.Title == title)
               .To<T>()
               .FirstOrDefault();

            return movie;
        }

        public async Task Edit(MovieEditModel input)
        {
            var movie = this.moviesRepository
                .All()
                .FirstOrDefault(x => x.Id == input.Id);

            movie.Title = input.Title;
            movie.Year = input.Year;
            movie.ImageUrl = input.ImageUrl;
            movie.Description = input.Description;
            movie.HomePageLink = input.HomePageLink;
            movie.IMDBLink = input.IMDBLink;
            movie.TrailerLink = input.TrailerLink;
            movie.FacebookLink = input.FacebookLink;
            movie.Creater = input.Creater;
            movie.Producer = input.Producer;
            movie.Country = input.Country;

            this.moviesRepository.Update(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public async Task Delete(MovieEditModel input)
        {
            var movie = this.moviesRepository
                 .All()
                 .FirstOrDefault(x => x.Id == input.Id);

            movie.IsDeleted = true;
            movie.DeletedOn = DateTime.UtcNow;
            this.moviesRepository.Update(movie);
            await this.moviesRepository.SaveChangesAsync();
        }

        public T GetById<T>(int id)
        {
            var movie = this.moviesRepository.All().Where(x => x.Id == id)
               .To<T>().FirstOrDefault();
            return movie;
        }
    }
}
