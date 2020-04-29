namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Common.Models;

    public class Genre : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
