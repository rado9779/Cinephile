namespace Cinephile.Data.Models
{
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public Genre()
        {
            this.Movies = new HashSet<MovieGenre>();
            this.TVShows = new HashSet<TVShowGenre>();
        }

        public string Name { get; set; }

        public virtual ICollection<MovieGenre> Movies { get; set; }

        public virtual ICollection<TVShowGenre> TVShows { get; set; }
    }
}
