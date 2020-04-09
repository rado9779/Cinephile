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
        private readonly IDeletableEntityRepository<ApplicationUser> usersRepository;

        public UsersService(
            IDeletableEntityRepository<Post> postsRepository,
            IDeletableEntityRepository<ApplicationUser> usersRepository)
        {
            this.postsRepository = postsRepository;
            this.usersRepository = usersRepository;
        }

        public IEnumerable<T> GetAllUserPosts<T>(string username)
        {
            IQueryable<Post> query = this.postsRepository
                 .All()
                 .Where(x => x.UserId != null)
                 .Where(x => x.User.UserName == username);

            return query.To<T>().ToList();
        }

        public T GetUserByName<T>(string username)
        {
            var user = this.usersRepository.All()
                  .Where(x => x.UserName == username)
                  .To<T>().FirstOrDefault();

            return user;
        }
    }
}
