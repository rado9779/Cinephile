namespace Cinephile.Web.ViewModels.Forum
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class IndexCategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public int PostsCount { get; set; }

        public string Url => $"/{this.Name.Replace(' ', '-')}";
    }
}
