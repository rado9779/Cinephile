namespace Cinephile.Web.Areas.Administration.Controllers
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Actors;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    public class ActorsController : AdministrationController
    {
        private readonly IActorsService actorsService;

        public ActorsController(IActorsService actorsService)
        {
            this.actorsService = actorsService;
        }

        [HttpGet]
        public IActionResult ActorView(string name)
        {
            var viewModel = this.actorsService
                .GetByTitle<ActorViewModel>(name);

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorCreateModel input)
        {
            var movie = AutoMapperConfig.MapperInstance.Map<Actor>(input);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.actorsService.Create(input);
            return this.RedirectToAction(nameof(this.ActorView), new { name = input.FirstName });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = this.actorsService.GetById<ActorEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActorEditModel input)
        {
            if (input == null)
            {
                return this.NotFound();
            }

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.actorsService.Edit(input);
            return this.RedirectToAction(nameof(this.ActorView), new { name = input.FirstName });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var viewModel = this.actorsService.GetById<ActorEditModel>(id);
            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(ActorEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.actorsService.Delete(input);
            return this.Redirect($"/Actors/ActorsIndex");
        }
    }
}
