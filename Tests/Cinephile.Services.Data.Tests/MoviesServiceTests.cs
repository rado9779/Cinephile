namespace Cinephile.Services.Data.Tests
{
    using System.Linq;
    using System.Reflection;
    using System.Threading.Tasks;

    using Cinephile.Data;
    using Cinephile.Data.Models;
    using Cinephile.Data.Repositories;
    using Cinephile.Services.Data.Tests.Common;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Movies;
    using Xunit;

    public class MoviesServiceTests
    {
        public MoviesServiceTests()
        {
            AutoMapperConfig.RegisterMappings(
              typeof(Movie).GetTypeInfo().Assembly,
              typeof(MovieViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetById_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository,genresRepository);

            var result = service.GetById<MovieViewModel>(1);

            Assert.Equal(1, result.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(111)]
        public async Task GetById_WithInvalidInput_ShouldReturnInalidResult(int id)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            Assert.Null(service.GetById<MovieViewModel>(id));
        }

        [Fact]
        public async Task GetByTitle_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetByTitle<MovieViewModel>("1");
            Assert.Equal("1", result.Title);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetByTitle_WithInvalidInput_ShouldReturnInvalidResult(string title)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            Assert.Null(service.GetByTitle<MovieViewModel>(title));
        }

        [Fact]
        public async Task GetAll_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetAll<MovieViewModel>().ToList();

            Assert.Equal(2, result.Count());
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Movies.Add(new Movie
            {
                Id = 1,
                Title = "1",
            });

            dbContext.Movies.Add(new Movie
            {
                Id = 2,
                Title = "2",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
