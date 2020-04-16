namespace Cinephile.Web.ViewModels.Comments
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class CommentInputViewModel : IMapTo<Comment>
    {
        public int PostId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
