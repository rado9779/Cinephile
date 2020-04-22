namespace Cinephile.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.TVShows;
    using Microsoft.AspNetCore.Mvc;

    public class TVShowsController : AdministrationController
    {
        private readonly ITVShowsService tvshowsService;

        public TVShowsController(ITVShowsService tvshowsService)
        {
            this.tvshowsService = tvshowsService;
        }

        [HttpGet]
        public IActionResult TVShowView(string title)
        {
            var viewModel = this.tvshowsService
                .GetByTitle<TVShowViewModel>(title);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TVShowsCreateModel input)
        {
            var tvshow = AutoMapperConfig.MapperInstance.Map<TVShow>(input);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.tvshowsService.Create(input);
            return this.RedirectToAction(nameof(this.TVShowView), new { title = input.Title });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.tvshowsService.GetById<TVShowsEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TVShowsEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.tvshowsService.Edit(input);
            return this.RedirectToAction(nameof(this.TVShowView), new { title = input.Title });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viewModel = this.tvshowsService.GetById<TVShowsEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(TVShowsEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.tvshowsService.Delete(input);
            return this.Redirect($"/TVShows/TVShowsIndex");
        }
    }
}
