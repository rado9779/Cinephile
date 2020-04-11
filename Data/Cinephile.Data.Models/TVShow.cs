namespace Cinephile.Data.Models
{
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class TVShow : BaseDeletableModel<int>
    {
        public TVShow()
        {
            this.Actors = new HashSet<Actor>();
        }

        public string Title { get; set; }

        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }

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
