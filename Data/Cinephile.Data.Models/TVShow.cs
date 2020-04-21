namespace Cinephile.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class TVShow : BaseDeletableModel<int>
    {
        public TVShow()
        {
            this.Actors = new HashSet<ActorTVShow>();
            this.Genres = new HashSet<TVShowGenre>();
        }

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
