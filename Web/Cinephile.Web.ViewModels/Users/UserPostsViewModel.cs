namespace Cinephile.Web.ViewModels.Users
{
    using System;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class UserPostsViewModel : IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string FormattedDate => this.CreatedOn.Date.ToString("dd/MM/yyyy");

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public string UserId { get; set; }

        public int VotesCount { get; set; }

        public Category Category { get; set; }

        public string CategoryUrl => $"/{this.Category.Name}";

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, UserPostsViewModel>();
        }
    }
}
