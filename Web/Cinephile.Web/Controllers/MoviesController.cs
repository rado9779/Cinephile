namespace Cinephile.Web.Controllers
{
    using Cinephile.Web.ViewModels.Movies;
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : Controller
    {
        public IActionResult MoviesIndex()
        {
            var viewModel = new AllMoviesViewModel()
            {

            };
            return this.View(viewModel);
        }

        public IActionResult MovieView()
        {
            return this.View();
        }
    }
}
