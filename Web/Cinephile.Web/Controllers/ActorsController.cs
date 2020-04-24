namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Actors;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;

    public class ActorsController : Controller
    {
        private const int ItemsPerPage = 1;

        private readonly IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        [HttpGet]
        public IActionResult ActorsIndex(int page = 1)
        {
            var viewModel = new AllActorsViewModel();

            if (viewModel == null)
            {
                return this.NotFound();

            }

            viewModel.Actors = this.actorsService.GetByActorsForPage<ActorViewModel>(ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.actorsService.GetActorsCount();

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

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
