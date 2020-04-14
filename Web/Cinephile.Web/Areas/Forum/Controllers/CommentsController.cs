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

        public async Task<IActionResult> Create(CommentInputViewModel input)
        {
            var userId = this.userManager.GetUserId(this.User);
            await this.commentsService.Create(input.PostId, userId, input.Content);
            return this.RedirectToAction("ById", "Posts", new { id = input.PostId });
        }
    }
}
