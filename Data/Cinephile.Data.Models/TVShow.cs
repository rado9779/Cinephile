namespace Cinephile.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Common.Models;

    public class TVShow : BaseDeletableModel<int>
    {
        public TVShow()
        {
            this.Actors = new HashSet<ActorTVShow>();
            this.Genres = new HashSet<Genre>();
        }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int Seasons { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string TrailerLink { get; set; }

        public string FacebookLink { get; set; }

        [Required]
        [MaxLength(100)]
        public string Creater { get; set; }

        [Required]
        [MaxLength(100)]
        public string Producer { get; set; }

        public ICollection<ActorTVShow> Actors { get; set; }

        public ICollection<Genre> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}
