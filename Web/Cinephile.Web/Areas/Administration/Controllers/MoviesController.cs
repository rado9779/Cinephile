namespace Cinephile.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Movies;
    using Microsoft.AspNetCore.Mvc;

    public class MoviesController : AdministrationController
    {
        private readonly IMoviesService moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            this.moviesService = moviesService;
        }

        [HttpGet]
        public IActionResult MovieView(string title)
        {
            var viewModel = this.moviesService.GetByTitle<MovieViewModel>(title);
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MovieCreateModel input)
        {
            var movie = AutoMapperConfig.MapperInstance.Map<Movie>(input);
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.moviesService.Create(input);
            return this.RedirectToAction(nameof(this.MovieView), new { title = input.Title });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.moviesService.GetById<MovieEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MovieEditModel input)
        {
            if (input == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.moviesService.Edit(input);
            return this.RedirectToAction(nameof(this.MovieView), new { title = input.Title });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viewModel = this.moviesService.GetById<MovieEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(MovieEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.moviesService.Delete(input);
            return this.Redirect($"/Movies/MoviesIndex");
        }
    }
}
