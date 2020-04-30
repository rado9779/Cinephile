namespace Cinephile.Web.Controllers
{
    using System.Threading.Tasks;

    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Web.ViewModels.Comments;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Forum")]
    public class CommentsController : Controller
    {
        private readonly ICommentsService commentsService;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentsController(
            ICommentsService commentsService,
            UserManager<ApplicationUser> userManager)
        {
            this.commentsService = commentsService;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommentInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(input.PostId, userId, input.Content);
            return this.RedirectToAction("ById", "Posts", new { id = input.PostId });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var viewModel = this.commentsService.GetById<CommentEditModel>(id);

            var user = await this.userManager.GetUserAsync(this.User);

            if (user.Id == viewModel.UserId || this.User.IsInRole("Administrator"))
            {
                return this.View(viewModel);
            }

            return this.Redirect($"/Forum/Forum");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.commentsService.Edit(input);

            return this.Redirect($"/Forum/Forum");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var viewModel = this.commentsService.GetById<CommentEditModel>(id);

            var user = await this.userManager.GetUserAsync(this.User);

            if (user.Id == viewModel.UserId || this.User.IsInRole("Administrator"))
            {
                return this.View(viewModel);
            }

            return this.Redirect($"/Forum/Forum");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(CommentEditModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(input);
            }

            await this.commentsService.Delete(input);
            return this.Redirect($"/Forum/Forum");
        }
    }
}
