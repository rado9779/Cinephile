namespace Cinephile.Web.ViewModels.Posts
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class PostInputModel : IMapTo<Post>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public int CategoryId { get; set; }

        public IEnumerable<PostCategoriesViewModel> Categories { get; set; }
    }
}
