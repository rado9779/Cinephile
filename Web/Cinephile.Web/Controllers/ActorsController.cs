namespace Cinephile.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ActorsController : Controller
    {
        public IActionResult ActorsIndex()
        {
            return this.View();
        }
    }
}
