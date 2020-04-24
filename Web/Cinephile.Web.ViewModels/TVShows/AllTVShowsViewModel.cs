namespace Cinephile.Web.ViewModels.TVShows
{
    using System.Collections.Generic;

    public class AllTVShowsViewModel
    {
        public IEnumerable<TVShowViewModel> TVShows { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
