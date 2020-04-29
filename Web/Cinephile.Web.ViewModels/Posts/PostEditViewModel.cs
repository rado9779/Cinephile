namespace Cinephile.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class PostEditViewModel : IMapTo<Post>, IMapFrom<Post>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string Category { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<PostCategoriesViewModel> Categories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
