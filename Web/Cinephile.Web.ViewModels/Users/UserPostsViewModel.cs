namespace Cinephile.Web.ViewModels.Users
{
    using System;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class UserPostsViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
