namespace Cinephile.Web.ViewModels.Movies
{
    using System.Collections.Generic;

    public class AllMoviesViewModel
    {
        public IEnumerable<MovieViewModel> Movies { get; set; }
    }
}
