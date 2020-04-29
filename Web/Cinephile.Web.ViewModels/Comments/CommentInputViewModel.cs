namespace Cinephile.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class CommentInputViewModel : IMapTo<Comment>
    {
        [Required]
        public int PostId { get; set; }

        [Required]
        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
