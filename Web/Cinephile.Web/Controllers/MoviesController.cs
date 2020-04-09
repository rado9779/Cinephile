namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Movies;
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : Controller
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        public IActionResult MoviesIndex()
        {
            var viewModel = new AllMoviesViewModel()
            {
                Movies = this.moviesService.GetAll<MovieViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult MovieView()
        {
            return this.View();
        }
    }
}
