namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ActorMovie
    {
        [Required]
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }

        [Required]
        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }
    }
}
