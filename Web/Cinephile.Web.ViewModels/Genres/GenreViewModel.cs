namespace Cinephile.Web.ViewModels.Genres
{

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class GenreViewModel : IMapFrom<Genre>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
