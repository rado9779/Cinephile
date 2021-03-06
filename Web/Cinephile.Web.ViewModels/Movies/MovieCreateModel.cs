﻿namespace Cinephile.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Genres;

    public class MovieCreateModel : IMapTo<Movie>
    {
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public string Description { get; set; }

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

        [Required]
        [MaxLength(100)]

        public string Country { get; set; }

        public DateTime ReleaseDate { get; set; }

        public ICollection<ActorMovie> Actors { get; set; }

        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }
    }
}
