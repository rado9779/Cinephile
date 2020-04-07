namespace Cinephile.Web.Controllers
{
    using Cinephile.Web.ViewModels.Actors;
    using Microsoft.AspNetCore.Mvc;

    public class ActorsController : Controller
    {
        public IActionResult ActorsIndex()
        {
            var viewModel = new AllActorsViewModel()
            {

            };
            return this.View(viewModel);
        }

        public IActionResult ActorView()
        {
            return this.View();
        }
    }
}
