namespace Cinephile.Data.Models
{
    using System.Collections.Generic;

    using Cinephile.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        public string Name { get; set; }
    }
}
