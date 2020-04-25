namespace Cinephile.Services.Data.Tests
{
    using System.Threading.Tasks;
    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Xunit;

    public class CommentsServiceTests
    {

        [Fact]
        public async Task GetById_WithCorrectData_ShouldReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();

            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetCountByPostId(1);

            Assert.Equal(2, result);
        }

        private async Task CreateTestComments(ApplicationDbContext dbContext)
        {
            dbContext.Comments.Add(new Comment
            {
                Id = 1,
                PostId = 1,
            });
            dbContext.Comments.Add(new Comment
            {
                Id = 2,
                PostId = 1,
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
