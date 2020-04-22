namespace Cinephile.Web.ViewModels.TVShows
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class TVShowsCreateModel : IMapTo<TVShow>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public int Seasons { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string TrailerLink { get; set; }

        public string FacebookLink { get; set; }

        public string Creater { get; set; }

        public string Producer { get; set; }

        public ICollection<ActorTVShow> Actors { get; set; }

        public ICollection<TVShowGenre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Country { get; set; }
    }
}
