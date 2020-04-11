namespace Cinephile.Data.Models
{
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.Movies = new HashSet<Movie>();
            this.TVShows = new HashSet<TVShow>();
        }

        public string Name { get; set; }

        public virtual ICollection<Movie> Movies { get; set; }

        public virtual ICollection<TVShow> TVShows { get; set; }
    }
}
