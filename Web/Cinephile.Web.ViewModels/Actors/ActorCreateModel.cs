﻿namespace Cinephile.Web.ViewModels.Actors
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class ActorCreateModel : IMapTo<Actor>
    {
        public int Id { get; set; }

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

        public ICollection<ActorMovie> Movies { get; set; }

        public ICollection<ActorTVShow> TVShows { get; set; }
    }
}