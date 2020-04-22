namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Actors;
    using Microsoft.AspNetCore.Mvc;

    public class ActorsController : Controller
    {
        private readonly IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        public IActionResult ActorsIndex()
        {
            var viewModel = new AllActorsViewModel()
            {
                Actors = this.actorsService.GetAll<ActorViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult ActorView()
        {
            return this.View();
        }
    }
}
