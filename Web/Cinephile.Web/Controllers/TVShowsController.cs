namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.TVShows;
    using Microsoft.AspNetCore.Mvc;

    public class TVShowsController : Controller
    {
        private readonly ITVShowsService tvshowsService;

        public TVShowsController(ITVShowsService tvshowsService)
        {
            this.tvshowsService = tvshowsService;
        }

        [HttpGet]
        public IActionResult TVShowsIndex()
        {
            var viewModel = new AllTVShowsViewModel()
            {
                TVShows = this.tvshowsService
                .GetAll<TVShowViewModel>(),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult TVShowView(string title)
        {
            var viewModel = this.tvshowsService
                .GetByTitle<TVShowViewModel>(title);

            return this.View(viewModel);
        }
    }
}
