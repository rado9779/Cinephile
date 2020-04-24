namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Actors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        [HttpGet]
        public IActionResult ActorsIndex()
        {
            var viewModel = new AllActorsViewModel()
            {
                Actors = this.actorsService.GetAll<ActorViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult ActorView(string name)
        {
            var viewModel = this.actorsService
                .GetByTitle<ActorViewModel>(name);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult ActorsByQuery(string input)
        {
            var viewModel = new AllActorsViewModel
            {
                Actors = this.actorsService.GetAllByQuery<ActorViewModel>(input),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
