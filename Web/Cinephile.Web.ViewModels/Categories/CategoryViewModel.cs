namespace Cinephile.Web.ViewModels.Categories
{
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class CategoryViewModel : IMapFrom<Category>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

    }
}
