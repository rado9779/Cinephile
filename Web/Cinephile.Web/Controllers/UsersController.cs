namespace Cinephile.Web.Controllers
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Data;
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

        public IActionResult UserPosts(string userId)
        {
            var userPosts = this.usersService.GetAllUserPosts<UserPostsViewModel>(userId);

            var viewModel = new UserViewModel
            {
                UserPosts = userPosts,
            };
            return this.View(viewModel);
        }
    }
}
