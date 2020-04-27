namespace Cinephile.Web.ViewModels.Movies
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class MovieEditModel : IMapTo<Movie>, IMapFrom<Movie>
    {
        public int Id { get; set; }

        public string ImageUrl { get; set; }

        public string Title { get; set; }

        public int Year { get; set; }

        public string Description { get; set; }

        public string HomePageLink { get; set; }

        public string IMDBLink { get; set; }

        public string TrailerLink { get; set; }

        public string FacebookLink { get; set; }

        public string Creater { get; set; }

        public string Producer { get; set; }

        public string Country { get; set; }

        public ICollection<ActorMovie> Actors { get; set; }

        public ICollection<Genre> Genres { get; set; }
    }
}
