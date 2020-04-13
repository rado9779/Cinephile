namespace Cinephile.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class TVShow : BaseDeletableModel<int>
    {
        public TVShow()
        {
            this.Actors = new HashSet<Actor>();
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

        public ICollection<Actor> Actors { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EndDate { get; set; }

        public string Country { get; set; }
    }
}
