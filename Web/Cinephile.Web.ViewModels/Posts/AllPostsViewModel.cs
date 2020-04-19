namespace Cinephile.Web.ViewModels.Posts
{
    using System.Collections.Generic;

    public class AllPostsViewModel
    {
        public IEnumerable<PostViewModel> Posts { get; set; }

        public string PostQuery { get; set; }
    }
}
