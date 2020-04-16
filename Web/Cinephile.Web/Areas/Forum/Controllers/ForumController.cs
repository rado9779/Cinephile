namespace Cinephile.Web.Controllers
{
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Forum;
    using Cinephile.Web.ViewModels.Posts;
    using Microsoft.AspNetCore.Mvc;

    [Area("Forum")]
    public class ForumController : BaseController
    {
        private readonly IPostsService postsService;

        public ForumController(IPostsService postsService)
        {
            this.postsService = postsService;
        }

        public IActionResult Index()
        {
            var viewModel = new AllPostsViewModel
            {
                Posts = this.postsService.GetAll<PostViewModel>(),
            };

            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult Rules()
        {
            return this.View();
        }
    }
}
