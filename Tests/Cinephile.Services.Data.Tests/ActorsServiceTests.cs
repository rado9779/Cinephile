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
    using Cinephile.Web.ViewModels.Actors;
    using Xunit;

    public class ActorsServiceTests
    {
        public ActorsServiceTests()
        {
            AutoMapperConfig.RegisterMappings(
               typeof(Actor).GetTypeInfo().Assembly,
               typeof(ActorViewModel).GetTypeInfo().Assembly);
        }

        [Fact]
        public async Task GetById_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetById<ActorViewModel>(1);

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

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            Assert.Null(service.GetById<ActorViewModel>(id));
        }

        [Fact]
        public async Task GetByName_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetByTitle<ActorViewModel>("1");

            Assert.Equal("1", result.FirstName);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public async Task GetByName_WithInvalidInput_ShouldReturnInvalidResult(string name)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetByTitle<ActorViewModel>(name);

            Assert.Null(service.GetByTitle<ActorViewModel>(name));
        }

        [Fact]
        public async Task GetAllByQuery_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetAllByQuery<ActorViewModel>("1").ToList();

            Assert.Single(result);
        }

        [Theory]
        [InlineData("")]
        public async Task GetAllByQuery_WithNullInput_ShouldReturnValidResult(string name)
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetAllByQuery<ActorViewModel>(name).ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task GetAll_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetAll<ActorViewModel>().ToList();

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task Create_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var input = new ActorCreateModel()
            {
                FirstName = "Bob",
                LastName = "Ross",
                Gender = "Male",
            };

            var actor = service.Create(input);
            var result = service.GetByTitle<ActorViewModel>("Bob");

            Assert.Equal("Ross", result.LastName);
            Assert.Equal("Male", result.Gender);
        }

        [Fact]
        public async Task GetActorsCount_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetActorsCount();

            Assert.Equal(2, result);
        }

        [Fact]
        public async Task GetByActorsForPage_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);

            var service = new ActorsService(actorsRepository);

            var result = service.GetByActorsForPage<ActorViewModel>(1, 1);

            Assert.Single(result);
        }

        [Fact]
        public async Task Edit_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);
            var service = new ActorsService(actorsRepository);

            var viewModel = new ActorEditModel()
            {
                Id = 1,
                FirstName = "Edited",
            };

            var result = service.Edit(viewModel);

            Assert.Equal("Edited", viewModel.FirstName);
        }

        [Fact]
        public async Task Delete_WithValidInput_ShouldReturnValidResult()
        {
            var dbContext = ApplicationDbContextCreatorInMemory.InitializeContext();
            await this.SeedData(dbContext);

            var actorsRepository = new EfDeletableEntityRepository<Actor>(dbContext);
            var service = new ActorsService(actorsRepository);

            var actor = service.GetById<ActorEditModel>(1);

            var result = service.Delete(actor);

            Assert.Equal(1, dbContext.Actors.Count());
        }

        private async Task SeedData(ApplicationDbContext dbContext)
        {
            dbContext.Actors.Add(new Actor
            {
                Id = 1,
                FirstName = "1",
            });

            dbContext.Actors.Add(new Actor
            {
                Id = 2,
                FirstName = "2",
            });
            await dbContext.SaveChangesAsync();
        }
    }
}
