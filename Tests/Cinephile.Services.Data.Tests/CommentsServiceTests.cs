namespace Cinephile.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Cinephile.Web.ViewModels.Comments;
    using Xunit;

    public class CommentsServiceTests
    {
        [Fact]
        public async Task GetCountByPostId_WithCorrectInput_ShouldReturnCorrectResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetCountByPostId(1);

            Assert.Equal(3, result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(5)]
        public async Task GetCountByPostId_WithIncorrectInput_ShouldReturnZero(int id)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetCountByPostId(id);

            Assert.Equal(0, result);
        }

        [Fact]
        public async Task GetByPostId_WithCorrectInput_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            // PostId = 1
            // Take = 2
            // Skip = 1
            var result = service.GetByPostId<CommentEditModel>(1, 2, 1);

            Assert.Equal(2, result.Count(x => x.PostId == 1));
            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(5)]
        public async Task GetByPostId_WithIncorrectInput_ShouldReturnZeroResult(int postId)
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            // PostId = 1
            // Take = 2
            // Skip = 1
            var result = service.GetByPostId<CommentEditModel>(postId, 2, 1);

            Assert.Equal(0, result.Count(x => x.PostId == postId));
            Assert.Empty(result);
        }

        [Fact]
        public async Task Delete_WithCorrectId_ShouldRemoveComment()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var model = new CommentEditModel();
            model.Id = 1;

            await service.Delete(model);

            var result = repository.AllWithDeleted().Where(p => p.Id == 1).FirstOrDefault().IsDeleted;
            Assert.True(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(55555)]
        public async Task Delete_WithIncorrectId_ShouldThrowException(int id)
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var model = new CommentEditModel();
            model.Id = id;

            await Assert.ThrowsAsync<NullReferenceException>(() => service.Delete(model));
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllComments()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetAll<CommentEditModel>().ToList();

            Assert.Equal(5, result.Count);
        }


        [Fact]
        public async Task GetAll_WithNullData_ShouldThrowException()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetAll<CommentEditModel>().ToList();

            Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_WithCorrectId_ShouldReturnCorrectComment()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var result = service.GetById<CommentEditModel>(1);

            Assert.Equal(1, result.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(55555)]
        public async Task GetById_WithIncorrectId_ShouldReturnZeroComment(int id)
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            Assert.Null(service.GetById<CommentEditModel>(id));
        }

        [Fact]
        public async Task Create_WithValidDate_ShouldReturnComment()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var comment = service.Create(77, "2", "Hi");

            var result = repository.All().FirstOrDefault(x => x.PostId == 77);

            Assert.Equal(77, result.PostId);
            Assert.Equal("2", result.UserId);
            Assert.Equal("Hi", result.Content);
        }

        [Fact]
        public async Task Edit_WithValidInput_ShouldChangeContent()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var viewModel = new CommentEditModel()
            {
                Id = 1,
                Content = "Edited",
            };

            await service.Edit(viewModel);
            var comment = service.GetById<CommentEditModel>(1);

            Assert.Equal("Edited", comment.Content);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(55555)]
        public async Task Edit_WithInvalidId_ShouldThrowException(int id)
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestComments(dbContext);

            var repository = new EfDeletableEntityRepository<Comment>(dbContext);
            var service = new CommentsService(repository);

            var viewModel = new CommentEditModel()
            {
                Id = id,
            };

            await Assert.ThrowsAsync<NullReferenceException>(() => service.Edit(viewModel));
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
            dbContext.Comments.Add(new Comment
            {
                Id = 3,
                PostId = 1,
            });
            dbContext.Comments.Add(new Comment
            {
                Id = 4,
                PostId = 2,
            });
            dbContext.Comments.Add(new Comment
            {
                Id = 5,
                PostId = 2,
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
