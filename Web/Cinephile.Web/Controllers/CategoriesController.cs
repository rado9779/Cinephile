namespace Cinephile.Web.Controllers
{
    using System;

    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Categories;
    using Microsoft.AspNetCore.Mvc;

    public class CategoriesController : Controller
    {
        private const int ItemsPerPage = 5;

        private readonly ICategoriesService categoriesService;
        private readonly IPostsService postsService;

        public CategoriesController(ICategoriesService categoriesService, IPostsService postsService)
        {
            this.categoriesService = categoriesService;
            this.postsService = postsService;
        }

        public IActionResult AllCategories()
        {
            var viewModel = new AllCategoriesViewModel
            {
                Categories =
                    this.categoriesService.GetAll<CategoryIndexViewModel>(),
            };
            return this.View(viewModel);
        }

        public IActionResult CategoryByName(string name, int page = 1)
        {
            var viewModel =
               this.categoriesService.GetByName<CategoryViewModel>(name);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Posts = this.postsService.GetByCategoryId<CategoryPostsViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.postsService.GetCountByCategoryId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);
            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }
    }
}
