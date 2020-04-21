namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ActorTVShow
    {
        [Required]
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        [Required]
        public int TVShowId { get; set; }

        public virtual TVShow TVShow { get; set; }
    }
}
