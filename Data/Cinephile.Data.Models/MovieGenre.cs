namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class MovieGenre
    {
        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
