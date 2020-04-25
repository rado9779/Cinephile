namespace Cinephile.Web.Controllers
{
    using System;

    using Cinephile.Common;
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Genres;
    using Cinephile.Web.ViewModels.TVShows;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class TVShowsController : Controller
    {
        private const int ItemsPerPage = GlobalConstants.TVShowsPerPage;

        private readonly ITVShowsService tvshowsService;

        public TVShowsController(ITVShowsService tvshowsService)
        {
            this.tvshowsService = tvshowsService;
        }

        [HttpGet]
        public IActionResult TVShowsIndex(int page = 1)
        {
            var viewModel = new AllTVShowsViewModel();

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Genres = this.tvshowsService.GetAllGenres<GenreViewModel>();
            viewModel.TVShows = this.tvshowsService.GetTVShowsForPage<TVShowViewModel>(ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.tvshowsService.GetTVShowsCount();

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult TVShowView(string title)
        {
            var viewModel = this.tvshowsService
                .GetByTitle<TVShowViewModel>(title);

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult TVShowsByQuery(string input)
        {
            var viewModel = new AllTVShowsViewModel
            {
                TVShows = this.tvshowsService.GetAllByQuery<TVShowViewModel>(input),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
