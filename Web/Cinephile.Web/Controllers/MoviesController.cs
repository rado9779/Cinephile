﻿namespace Cinephile.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : Controller
    {
        public IActionResult MoviesIndex()
        {
            return this.View();
        }

        public IActionResult MovieView()
        {
            return this.View();
        }
    }
}