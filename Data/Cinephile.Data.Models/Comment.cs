namespace Cinephile.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}
