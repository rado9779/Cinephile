namespace Cinephile.Web.Controllers
{
    using Cinephile.Web.ViewModels.TVShows;
    using Microsoft.AspNetCore.Mvc;

    public class TVShowsController : Controller
    {
        public IActionResult TVShowsIndex()
        {
            var viewModel = new AllTVShowsViewModel();
            {

            }
            return this.View(viewModel);
        }

        public IActionResult TVShowView()
        {
            return this.View();
        }
    }
}
