namespace Cinephile.Web.ViewModels.Forum
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
