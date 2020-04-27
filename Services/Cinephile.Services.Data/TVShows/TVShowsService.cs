namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.TVShows;

    public class TVShowsService : ITVShowsService
    {
        private readonly IDeletableEntityRepository<TVShow> tvshowRepository;
        private readonly IDeletableEntityRepository<Genre> genresRepository;

        public TVShowsService(
            IDeletableEntityRepository<TVShow> tvshowRepository,
            IDeletableEntityRepository<Genre> genresRepository)
        {
            this.tvshowRepository = tvshowRepository;
            this.genresRepository = genresRepository;
        }

        public T GetById<T>(int id)
        {
            var tvshow = this.tvshowRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return tvshow;
        }

        public T GetByTitle<T>(string title)
        {
            var tvshow = this.tvshowRepository
               .All()
               .Where(x => x.Title == title)
               .To<T>()
               .FirstOrDefault();

            return tvshow;
        }

        public IEnumerable<T> GetAllByQuery<T>(string input)
        {
            IQueryable<TVShow> query = this.tvshowRepository
                   .All();

            if (input != null)
            {
                query = this.tvshowRepository
                  .All()
                  .Where(x => x.Title.Contains(input));
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<TVShow> query = this.tvshowRepository
                 .All()
                 .OrderBy(x => x.Title);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task Create(TVShowsCreateModel input)
        {
            var tvshow = new TVShow()
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
                Seasons = input.Seasons,
                ReleaseDate = input.ReleaseDate,
                EndDate = input.EndDate,
            };

            await this.tvshowRepository.AddAsync(tvshow);
            await this.tvshowRepository.SaveChangesAsync();
        }

        public async Task Edit(TVShowsEditModel input)
        {
            var tvshow = this.tvshowRepository
                 .All()
                 .FirstOrDefault(x => x.Id == input.Id);

            tvshow.Title = input.Title;
            tvshow.Year = input.Year;
            tvshow.ImageUrl = input.ImageUrl;
            tvshow.Description = input.Description;
            tvshow.HomePageLink = input.HomePageLink;
            tvshow.IMDBLink = input.IMDBLink;
            tvshow.TrailerLink = input.TrailerLink;
            tvshow.FacebookLink = input.FacebookLink;
            tvshow.Creater = input.Creater;
            tvshow.Producer = input.Producer;
            tvshow.Country = input.Country;
            tvshow.Seasons = tvshow.Seasons;
            tvshow.ReleaseDate = input.ReleaseDate;
            tvshow.EndDate = input.EndDate;

            this.tvshowRepository.Update(tvshow);
            await this.tvshowRepository.SaveChangesAsync();
        }

        public async Task Delete(TVShowsEditModel input)
        {
            var tvshow = this.tvshowRepository
                 .All()
                 .FirstOrDefault(x => x.Id == input.Id);

            tvshow.IsDeleted = true;
            tvshow.DeletedOn = DateTime.UtcNow;
            this.tvshowRepository.Update(tvshow);
            await this.tvshowRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetTVShowsForPage<T>(int? take = null, int skip = 0)
        {
            var query = this.tvshowRepository
                  .All()
                  .OrderByDescending(x => x.CreatedOn)
                  .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public int GetTVShowsCount()
        {
            return this.tvshowRepository
                .All()
                .Count();
        }

        public IEnumerable<T> GetAllGenres<T>(int? count = null)
        {
            var genres = this.genresRepository.
                All();

            return genres
                .To<T>()
                .ToList();
        }

        public IEnumerable<T> GetAllByGenre<T>(string genre)
        {
            IQueryable<TVShow> query = this.tvshowRepository
                   .All()
                   .Where(m => m.Genres.All(g => g.Name == genre));

            return query.To<T>().ToList();
        }
    }
}
