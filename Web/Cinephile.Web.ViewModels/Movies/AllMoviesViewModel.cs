namespace Cinephile.Web.ViewModels.Movies
{
    using Cinephile.Web.ViewModels.Genres;
    using System.Collections.Generic;

    public class AllMoviesViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
