namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Forum;
    using Microsoft.AspNetCore.Mvc;

    public class ForumController : BaseController
    {
        private readonly ICategoriesService categoriesService;

        public ForumController(ICategoriesService categoriesService)
        {
            this.categoriesService = categoriesService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                Categories =
                   this.categoriesService.GetAll<IndexCategoryViewModel>(),
            };

            return this.View(viewModel);
        }

        public IActionResult Rules()
        {
            return this.View();
        }
    }
}
