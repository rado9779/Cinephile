namespace Cinephile.Web.ViewModels.Actors
{
    using System.Collections.Generic;

    public class AllActorsViewModel
    {
        public IEnumerable<ActorViewModel> Actors { get; set; }

        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }
    }
}
