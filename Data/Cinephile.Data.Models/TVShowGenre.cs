namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class TVShowGenre
    {
        [Required]
        public int TVShowId { get; set; }

        public virtual TVShow Movie { get; set; }

        [Required]
        public int GenreId { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
