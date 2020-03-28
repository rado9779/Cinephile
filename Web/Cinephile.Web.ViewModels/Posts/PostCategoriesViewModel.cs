namespace Cinephile.Web.ViewModels.Posts
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class PostCategoriesViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
