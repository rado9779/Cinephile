namespace Cinephile.Web.ViewModels.Actors
{
    using System;
    using System.Collections.Generic;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Movies;
    using Cinephile.Web.ViewModels.TVShows;

    public class ActorViewModel : IMapFrom<Actor>, IMapFrom<ActorMovie>, IMapFrom<ActorTVShow>
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

        public IEnumerable<MovieViewModel> Movies { get; set; }

        public IEnumerable<TVShowViewModel> TVShows { get; set; }
    }
}
