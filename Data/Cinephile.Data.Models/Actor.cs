namespace Cinephile.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class Actor : BaseDeletableModel<int>
    {
        public Actor()
        {
            this.Movies = new HashSet<Movie>();
            this.TVShows = new HashSet<TVShow>();
        }

        public string ImageUrl { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Biography { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string FacebookLink { get; set; }

        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        public string Birthplace { get; set; }

        public ICollection<Movie> Movies { get; set; }

        public ICollection<TVShow> TVShows { get; set; }
    }
}
