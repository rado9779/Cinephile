namespace Cinephile.Web.ViewModels.Actors
{
    using System;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class ActorViewModel : IMapFrom<Actor>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthdate { get; set; }

        public string Biography { get; set; }

        public string ImageUrl { get; set; }
    }
}
