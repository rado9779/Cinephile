namespace Cinephile.Web.ViewModels.Posts
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;
    using Ganss.XSS;

    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedDate => this.CreatedOn.Date.ToString("dd/MM/yyyy");

        public string Title { get; set; }

        public string Content { get; set; }

        public string SanitizedContent => new HtmlSanitizer().Sanitize(this.Content);

        public string UserUserName { get; set; }

        public int VotesCount { get; set; }

        public Category Category { get; set; }

        public string CategoryUrl => $"/{this.Category.Name}";

        public IEnumerable<PostCommentsViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>();
        }
    }
}
