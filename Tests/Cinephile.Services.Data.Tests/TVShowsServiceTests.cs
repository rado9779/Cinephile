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
    using Cinephile.Web.ViewModels.Genres;
    using Cinephile.Web.ViewModels.TVShows;
    using Xunit;

    public class TVShowsServiceTests
    {
        public TVShowsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(
             typeof(TVShow).GetTypeInfo().Assembly,
             typeof(TVShowViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetById_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetById<TVShowViewModel>(1);

            Assert.Equal(1, result.Id);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(111)]
        public async Task GetById_WithInvalidInput_ShouldReturnInvalidResult(int id)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            Assert.Null(service.GetById<TVShowViewModel>(id));
        }

        [Fact]
        public async Task GetByTitle_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetByTitle<TVShowViewModel>("1");
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

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            Assert.Null(service.GetByTitle<TVShowViewModel>(title));
        }

        [Fact]
        public async Task GetAllByQuery_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetAllByQuery<TVShowViewModel>("1").ToList();

            Assert.Single(result);
        }

        [Theory]
        [InlineData("")]
        public async Task GetAllByQuery_WithNullInput_ShouldReturnValidResult(string title)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetAllByQuery<TVShowViewModel>(title).ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAll_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetAll<TVShowViewModel>().ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Create_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var input = new TVShowsCreateModel()
            {
                Title = "Titanic",
                Country = "USA",
                GenreId = 1,
            };

            var movie = service.Create(input);
            var result = service.GetByTitle<TVShowViewModel>("Titanic");

            Assert.Equal("USA", result.Country);
        }

        [Fact]
        public async Task Create_WithInvalidInput_ShouldThrowException()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var input = new TVShowsCreateModel()
            {
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(input));
        }

        [Fact]
        public async Task Edit_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var viewModel = new TVShowsEditModel()
            {
                Title = "Edited",
            };

            var result = service.Edit(viewModel);

            Assert.Equal("Edited", viewModel.Title);
        }

        [Fact]
        public async Task Delete_WithValidInput_ShouldReturnRemoveTVShow()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var tvshow = service.GetById<TVShowsEditModel>(1);

            var result = service.Delete(tvshow);

            Assert.Equal(1, dbContext.TVShows.Count());
        }

        [Fact]
        public async Task GetTVShowsForPage_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetTVShowsForPage<TVShowViewModel>(1, 1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetTVShowsCount_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetTVShowsCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetAllGenres_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var tvshowRepository = new EfDeletableEntityRepository<TVShow>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new TVShowsService(tvshowRepository, genresRepository);

            var result = service.GetAllGenres<GenreViewModel>().ToList();

            Assert.Single(result);
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            dbContext.TVShows.Add(new TVShow
            {
                Id = 1,
                Title = "1",
            });

            dbContext.TVShows.Add(new TVShow
            {
                Id = 2,
                Title = "2",
            });
            await dbContext.SaveChangesAsync();

            dbContext.Genres.Add(new Genre
            {
                Id = 1,
                Name = "Drama",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
