namespace Cinephile.Services.Data
{
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
    }
}
