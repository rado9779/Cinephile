namespace Cinephile.Web.ViewModels.Comments
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class CommentEditModel : IMapFrom<Comment>, IMapTo<Comment>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PostId { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);
    }
}
