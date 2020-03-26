namespace Cinephile.Web.ViewModels.Posts
{
    using System;

    using AutoMapper;
    using Cinephile.Data.Models;
    using Cinephile.Services.Mapping;

    public class PostViewModel : IMapFrom<Post>, IMapTo<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string UserUserName { get; set; }

        public int VotesCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Post, PostViewModel>();
        }
    }
}
