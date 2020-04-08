namespace Cinephile.Web.ViewModels.Comments
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class CommentInputViewModel : IMapTo<Comment>
    {
        public int PostId { get; set; }

        public string Content { get; set; }
    }
}
