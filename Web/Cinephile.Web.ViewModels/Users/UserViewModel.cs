namespace Cinephile.Web.ViewModels.Users
{
    using System.Collections.Generic;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public IEnumerable<UserPostsViewModel> UserPosts { get; set; }
    }
}
