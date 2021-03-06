﻿namespace Cinephile.Services.Data.Tests
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
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetById<MovieViewModel>(1);

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

        [Fact]
        public async Task GetAllByQuery_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetAllByQuery<MovieViewModel>("1").ToList();

            Assert.Single(result);
        }

        [Theory]
        [InlineData("")]
        public async Task GetAllByQuery_WithNullInput_ShouldReturnValidResult(string title)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetAllByQuery<MovieViewModel>(title).ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Create_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var input = new MovieCreateModel()
            {
                Title = "Titanic",
                Country = "USA",
                GenreId = 1,
            };

            var movie = service.Create(input);
            var result = service.GetByTitle<MovieViewModel>("Titanic");

            Assert.Equal("USA", result.Country);
        }

        [Fact]
        public async Task Create_WithInvalidInput_ShouldThrowException()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var input = new MovieCreateModel()
            {
            };

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.Create(input));
        }

        [Fact]
        public async Task Edit_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var viewModel = new MovieEditModel()
            {
                Title = "Edited",
            };

            var result = service.Edit(viewModel);

            Assert.Equal("Edited", viewModel.Title);
        }

        [Fact]
        public async Task Delete_WithValidInput_ShouldReturnRemoveMovie()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var movie = service.GetById<MovieEditModel>(1);

            var result = service.Delete(movie);

            Assert.Equal(1, dbContext.Movies.Count());
        }

        [Fact]
        public async Task GetMoviesForPage_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetByMoviesForPage<MovieViewModel>(1, 1);

            Assert.Single(result);
        }

        [Fact]
        public async Task GetMoviesCount_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);
            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetMoviesCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetAllGenres_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var moviesRepository = new EfDeletableEntityRepository<Movie>(dbContext);
            var genresRepository = new EfDeletableEntityRepository<Genre>(dbContext);
            var service = new MoviesService(moviesRepository, genresRepository);

            var result = service.GetAllGenres<GenreViewModel>().ToList();

            Assert.Single(result);
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

            dbContext.Genres.Add(new Genre
            {
                Id = 1,
                Name = "Drama",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
