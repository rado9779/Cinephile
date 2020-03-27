namespace Cinephile.Web.ViewModels.Categories
{
    using System;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class CategoryPostsViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
