namespace Cinephile.Web.ViewModels.Actors
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class ActorCreateModel : IMapTo<Actor>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        public string Biography { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string FacebookLink { get; set; }

        [Required]
        [MaxLength(10)]
        public string Gender { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        public string Birthplace { get; set; }

        public ICollection<ActorMovie> Movies { get; set; }

        public ICollection<ActorTVShow> TVShows { get; set; }
    }
}
