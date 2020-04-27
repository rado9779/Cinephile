namespace Cinephile.Web.Controllers
{
    using System;

    using Cinephile.Common;
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Genres;
    using Cinephile.Web.ViewModels.Movies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : Controller
    {
        private const int ItemsPerPage = GlobalConstants.MoviesPerPage;
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult MoviesIndex(int page = 1)
        {
            var viewModel = new AllMoviesViewModel();

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Genres = this.moviesService.GetAllGenres<GenreViewModel>();
            viewModel.Movies = this.moviesService.GetByMoviesForPage<MovieViewModel>(ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.moviesService.GetMoviesCount();

            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult MovieView(string title)
        {
            var viewModel = this.moviesService.GetByTitle<MovieViewModel>(title);
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult MoviesByQuery(string input)
        {
            var viewModel = new AllMoviesViewModel
            {
                Movies = this.moviesService.GetAllByQuery<MovieViewModel>(input),
                Genres = this.moviesService.GetAllGenres<GenreViewModel>(),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult MoviesByGenre(string genre)
        {
            var viewModel = new AllMoviesViewModel
            {
                Movies = this.moviesService.GetAllByGenre<MovieViewModel>(genre),
                Genres = this.moviesService.GetAllGenres<GenreViewModel>(),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }
    }
}
