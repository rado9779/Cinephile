namespace Cinephile.Services.Data.Tests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;

    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Cinephile.Web.ViewModels.Categories;
    using Cinephile.Web.ViewModels.Comments;
    using Xunit;

    public class CategoriesServiceTests
    {
        [Fact]
        public async Task GetByName_WithCorrectInput_ShouldReturnCorrectResult()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestCategories(dbContext);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);

            var result = service.GetByName<CategoryViewModel>("People");

            Assert.Equal("People", result.Name);
            Assert.Equal(1, result.Id);
        }

        // TODO: Test with Incorrect Input

        [Fact]
        public async Task GetAll_ShouldReturnAllCategories()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.CreateTestCategories(dbContext);

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);

            var result = service.GetAll<CategoryViewModel>().ToList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetAll_WithNullData_ShouldThrowEmptyResult()
        {
            MapperInitializer.InitializeMapper();
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();

            var repository = new EfDeletableEntityRepository<Category>(dbContext);
            var service = new CategoriesService(repository);

            var result = service.GetAll<CategoryViewModel>().ToList();

            Assert.Empty(result);
        }

        private async Task CreateTestCategories(ApplicationDbContext dbContext)
        {
            dbContext.Categories.Add(new Category
            {
                Id = 1,
                Name = "People",
            });
            dbContext.Categories.Add(new Category
            {
                Id = 2,
                Name = "Animals",
            });

            await dbContext.SaveChangesAsync();
        }
    }
}
