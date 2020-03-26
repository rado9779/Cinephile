namespace Cinephile.Web.ViewModels.Posts
{
    using System.ComponentModel.DataAnnotations;

    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class PostInputModel : IMapTo<Post>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

    }
}
