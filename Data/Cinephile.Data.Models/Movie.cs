namespace Cinephile.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class Movie : BaseDeletableModel<int>
    {
        public Movie()
        {
            this.Actors = new HashSet<ActorMovie>();
            this.Genres = new HashSet<MovieGenre>();
        }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string TrailerLink { get; set; }

        public string FacebookLink { get; set; }

        public string Creater { get; set; }

        public string Producer { get; set; }

        public ICollection<ActorMovie> Actors { get; set; }

        public ICollection<MovieGenre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Country { get; set; }
    }
}
