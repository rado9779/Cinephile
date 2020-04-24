namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Actors;

    public class ActorsService : IActorsService
    {
        private readonly IDeletableEntityRepository<Actor> actorsRepository;

        public ActorsService(IDeletableEntityRepository<Actor> actorsRepository)
        {
            this.actorsRepository = actorsRepository;
        }

        public T GetById<T>(int id)
        {
            var actor = this.actorsRepository
                .All()
                .Where(x => x.Id == id)
                .To<T>()
                .FirstOrDefault();

            return actor;
        }

        public T GetByTitle<T>(string name)
        {
            var actor = this.actorsRepository
                 .All()
                 .Where(x => x.FirstName == name)
                 .To<T>()
                 .FirstOrDefault();

            return actor;
        }

        public IEnumerable<T> GetAllByQuery<T>(string input)
        {
            IQueryable<Actor> query = this.actorsRepository
                  .All();

            if (input != null)
            {
                query = this.actorsRepository
                 .All()
                 .Where(x => x.FirstName.Contains(input) || x.LastName.Contains(input));
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Actor> query = this.actorsRepository
                 .All()
                 .OrderBy(x => x.FirstName);

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public async Task Create(ActorCreateModel input)
        {
            var actor = new Actor()
            {
                FirstName = input.FirstName,
                LastName = input.LastName,
                Biography = input.Biography,
                ImageUrl = input.ImageUrl,
                HomePageLink = input.HomePageLink,
                IMDBLink = input.IMDBLink,
                FacebookLink = input.FacebookLink,
                Birthdate = input.Birthdate,
                Birthplace = input.Birthplace,
            };

            await this.actorsRepository.AddAsync(actor);
            await this.actorsRepository.SaveChangesAsync();
        }

        public async Task Edit(ActorEditModel input)
        {
            var actor = this.actorsRepository
                  .All()
                  .FirstOrDefault(x => x.Id == input.Id);

            actor.FirstName = input.FirstName;
            actor.LastName = input.LastName;
            actor.ImageUrl = input.ImageUrl;
            actor.Biography = input.Biography;
            actor.HomePageLink = input.HomePageLink;
            actor.IMDBLink = input.IMDBLink;
            actor.FacebookLink = input.FacebookLink;
            actor.Birthdate = input.Birthdate;
            actor.Birthplace = input.Birthplace;
            actor.Gender = input.Gender;

            this.actorsRepository.Update(actor);
            await this.actorsRepository.SaveChangesAsync();
        }

        public async Task Delete(ActorEditModel input)
        {
            var actor = this.actorsRepository
                  .All()
                  .FirstOrDefault(x => x.Id == input.Id);

            actor.IsDeleted = true;
            actor.DeletedOn = DateTime.UtcNow;
            this.actorsRepository.Update(actor);
            await this.actorsRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetByActorsForPage<T>(int? take = null, int skip = 0)
        {
            var query = this.actorsRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Skip(skip);

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public int GetActorsCount()
        {
            return this.actorsRepository
               .All()
               .Count();
        }
    }
}
