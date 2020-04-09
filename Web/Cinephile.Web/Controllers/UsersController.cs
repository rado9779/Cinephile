namespace Cinephile.Web.Controllers
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Posts;
    using Cinephile.Web.ViewModels.Users;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public IActionResult UserPosts(string username)
        {
            var viewModel =
              this.usersService.GetUserByName<UserViewModel>(username);

            if (viewModel == null)
            {
                return this.NotFound();
            }

            viewModel.UserPosts = this.usersService.GetAllUserPosts<UserPostsViewModel>(username);

            return this.View(viewModel);
        }
    }
}
