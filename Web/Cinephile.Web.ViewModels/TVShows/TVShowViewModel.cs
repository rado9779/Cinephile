namespace Cinephile.Web.ViewModels.TVShows
{
    using System.Collections.Generic;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class TVShowViewModel : IMapFrom<TVShow>
    {
        public string Title { get; set; }

        public string Genre { get; set; }

        public string ReleaseYear { get; set; }

        public int EndYear { get; set; }

        public int Seasons { get; set; }

        public string Description { get; set; }

        public string CreatedBy { get; set; }

        public string Producer { get; set; }

        public ICollection<Actor> Actors { get; set; }

        public string ImageUrl { get; set; }
    }
}
