namespace Cinephile.Web.ViewModels.TVShows
{
    using System.Collections.Generic;

    using Cinephile.Web.ViewModels.Genres;

    public class AllTVShowsViewModel
    {
        public IEnumerable<TVShowViewModel> TVShows { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
