namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class UsersService : IUsersService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public UsersService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public IEnumerable<T> GetAllUserPosts<T>(string userId)
        {
            IQueryable<Post> query = this.postsRepository
                 .All()
                 .Where(x => x.UserId == userId);

            return query.To<T>().ToList();
        }
    }
}
