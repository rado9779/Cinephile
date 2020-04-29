namespace Cinephile.Web.ViewModels.TVShows
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Genres;

    public class TVShowsCreateModel : IMapTo<TVShow>
    {
        public int Id { get; set; }

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

        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public DateTime ReleaseDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; }
    }
}
