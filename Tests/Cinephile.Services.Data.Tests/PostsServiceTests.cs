namespace Cinephile.Services.Data.Tests
{
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Cinephile.Web.ViewModels.Posts;
    using Xunit;

    public class PostsServiceTests
    {
        [Fact]
        public async Task GetById_WithCorrectId_ShouldReturnCorrectPost()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestPosts(dbContext);

            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var commentsRepository = new EfDeletableEntityRepository<Comment>(dbContext);

            var service = new PostsService(postsRepository, commentsRepository);

            var result = service.GetById<PostViewModel>(1);

            Assert.Equal(1, result.Id);
        }

        private async Task CreateTestPosts(ApplicationDbContext dbContext)
        {
            dbContext.Posts.Add(new Post
            {
                Id = 1,
            });
            dbContext.Posts.Add(new Post
            {
                Id = 2,
            });
            dbContext.Posts.Add(new Post
            {
                Id = 3,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
