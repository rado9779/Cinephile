namespace Cinephile.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Username { get; set; }

        public IEnumerable<UserPostsViewModel> UserPosts { get; set; }
    }
}
