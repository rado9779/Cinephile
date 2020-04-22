namespace Cinephile.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class PostsController : AdministrationController
    {
        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ById(int id)
        {
            var postViewModel = this.postsService.GetById<PostViewModel>(id);

            if (postViewModel == null)
            {
                return this.NotFound();
            }

            return this.View(postViewModel);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            var categories = this.categoriesService.GetAll<PostCategoriesViewModel>();

            var viewModel = new PostInputModel
            {
                Categories = categories,
            };
            return this.View(viewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(PostInputModel input)
        {
            var post = AutoMapperConfig.MapperInstance.Map<Post>(input);

            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            var user = await this.userManager.GetUserAsync(this.User);
            var postId = await this.postsService.Create(input.Title, input.Content, input.CategoryId, user.Id);
            return this.RedirectToAction(nameof(this.ById), new { id = postId });
        }

        [HttpGet]
        [Authorize]
        public IActionResult PostsByTitle(string title)
        {
            var viewModel = new AllPostsViewModel
            {
                Posts = this.postsService.GetByTitle<PostViewModel>(title),
                PostQuery = title,
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = this.categoriesService.GetAll<PostCategoriesViewModel>();
            var viewModel = this.postsService.GetById<PostEditViewModel>(id);
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(PostEditViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.Edit(input);
            return this.Redirect($"/Forum/Posts/ById/{input.Id}");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var categories = this.categoriesService.GetAll<PostCategoriesViewModel>();
            var viewModel = this.postsService.GetById<PostEditViewModel>(id);
            viewModel.Categories = categories;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(PostEditViewModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.postsService.Delete(input);
            return this.Redirect($"/Forum/Forum");
        }
    }
}
