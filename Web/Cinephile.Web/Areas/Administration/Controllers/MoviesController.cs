namespace Cinephile.Web.Areas.Administration.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : AdministrationController
    {
        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }
    }
}
