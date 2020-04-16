namespace Cinephile.Web.ViewModels.Categories
{
    using System;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class CategoryPostsViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public int CommentsCount { get; set; }
    }
}
