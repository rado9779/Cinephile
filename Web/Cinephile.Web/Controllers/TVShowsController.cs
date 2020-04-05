namespace Cinephile.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class TVShowsController : Controller
    {
        public IActionResult TVShowsIndex()
        {
            return this.View();
        }

        public IActionResult TVShowView()
        {
            return this.View();
        }
    }
}
