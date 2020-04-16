namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data.Common.Repositories;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class PostsService : IPostsService
    {
        private readonly IDeletableEntityRepository<Post> postsRepository;

        public PostsService(IDeletableEntityRepository<Post> postsRepository)
        {
            this.postsRepository = postsRepository;
        }

        public async Task<int> Create(string title, string content, int categoryId, string userId)
        {
            var post = new Post
            {
                Title = title,
                Content = content,
                CategoryId = categoryId,
                UserId = userId,
            };

            await this.postsRepository.AddAsync(post);
            await this.postsRepository.SaveChangesAsync();

            return post.Id;
        }

        public T GetById<T>(int id)
        {
            var post = this.postsRepository.All().Where(x => x.Id == id)
                .To<T>().FirstOrDefault();
            return post;
        }

        public IEnumerable<T> GetAll<T>(int? count = null)
        {
            IQueryable<Post> query =
                this.postsRepository
                .All();

            if (count.HasValue)
            {
                query = query.Take(count.Value);
            }

            return query.To<T>().ToList();
        }

        public IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0)
        {
            var query = this.postsRepository
                .All()
                .OrderByDescending(x => x.CreatedOn)
                .Where(x => x.CategoryId == categoryId)
                .Skip(skip);
            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return query.To<T>().ToList();
        }

        public int GetCountByCategoryId(int categoryId)
        {
            return this.postsRepository.All().Count(x => x.CategoryId == categoryId);
        }

        public IEnumerable<T> GetByTitle<T>(string title)
        {
            IQueryable<Post> query = this.postsRepository
                 .All()
                 .Where(x => x.Title.Contains(title));

            return query.To<T>().ToList();
        }
    }
}
