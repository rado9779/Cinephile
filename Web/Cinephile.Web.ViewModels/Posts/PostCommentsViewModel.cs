namespace Cinephile.Web.ViewModels.Posts
{
    using System;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class PostCommentsViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }
    }
}
