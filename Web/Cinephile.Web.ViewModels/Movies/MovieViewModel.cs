namespace Cinephile.Web.ViewModels.Movies
{
    using System.Collections.Generic;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class MovieViewModel : IMapFrom<Movie>
    {
        public string Title { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }

        public string CreatedBy { get; set; }

        public string Producer { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public string ImageUrl { get; set; }
    }
}
