namespace ForumSystem.Web.Controllers
{
    using System;
    using System.Threading.Tasks;

    using AutoMapper;
    using Cinephile.Common;
    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Forum")]
    public class PostsController : Controller
    {
        private const int ItemsPerPage = GlobalConstants.CommentsPerPage;

        private readonly IPostsService postsService;
        private readonly ICategoriesService categoriesService;
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IMapper mapper;

        public PostsController(
            IPostsService postsService,
            ICategoriesService categoriesService,
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.postsService = postsService;
            this.categoriesService = categoriesService;
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public IActionResult ById(int id, int page = 1)
        {
            var viewModel =
              this.postsService.GetById<PostViewModel>(id);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.Comments = this.commentsService.GetByPostId<PostCommentsViewModel>(viewModel.Id, ItemsPerPage, (page - 1) * ItemsPerPage);

            var count = this.commentsService.GetCountByPostId(viewModel.Id);
            viewModel.PagesCount = (int)Math.Ceiling((double)count / ItemsPerPage);

            if (viewModel.PagesCount == 0)
            {
                viewModel.PagesCount = 1;
            }

            viewModel.CurrentPage = page;

            return this.View(viewModel);
        }

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
            if (input == null)
            {
                return this.NotFound();
            }

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
