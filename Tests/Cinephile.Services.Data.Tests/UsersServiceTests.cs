namespace Cinephile.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Users;
    using Xunit;

    public class UsersServiceTests
    {
        public UsersServiceTests()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(ApplicationUser).GetTypeInfo().Assembly,
                typeof(UserViewModel).GetTypeInfo().Assembly);

            AutoMapperConfig.RegisterMappings(
                typeof(ApplicationUser).GetTypeInfo().Assembly,
                typeof(UserPostsViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetUserByName_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(postsRepository, usersRepository);

            var result = service.GetUserByName<UserViewModel>("TheOne");

            Assert.Equal("1", result.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        public async Task GetUserByName_WithInvalidInput_ShouldReturnNullResult(string username)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(postsRepository, usersRepository);

            var result = service.GetUserByName<UserViewModel>(username);

            Assert.Null(service.GetUserByName<UserViewModel>(username));
        }

        [Fact]
        public async Task GetAllUserPosts_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(postsRepository, usersRepository);

            var result = service.GetAllUserPosts<UserPostsViewModel>("TheOne").ToList();
            var post = result.First();

            Assert.Single(result);
            Assert.Equal(1, post.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("1")]
        public async Task GetAllUserPosts_WithInvalidInput_ShouldReturtNullResult(string username)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var postsRepository = new EfDeletableEntityRepository<Post>(dbContext);
            var usersRepository = new EfDeletableEntityRepository<ApplicationUser>(dbContext);

            var service = new UsersService(postsRepository, usersRepository);

            var result = service.GetAllUserPosts<UserPostsViewModel>(username).ToList();

            Assert.True(result.Count == 0);
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Users.Add(new ApplicationUser
            {
                Id = "1",
                UserName = "TheOne",
            });

            dbContext.Posts.Add(new Post
            {
               Id = 1,
               UserId = "1",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
