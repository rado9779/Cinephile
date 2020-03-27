namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Administration.Dashboard;
    using Cinephile.Web.ViewModels.Categories;
    using Cinephile.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private readonly ICategoriesService categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new AllCategoriesViewModel
            {
                Categories =
                    this.categoriesService.GetAll<CategoryViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult ByName(string name)
        {
            var viewModel =
                this.categoriesService.GetByName<CategoryViewModel>(name);
            return this.View(viewModel);
        }
    }
}
