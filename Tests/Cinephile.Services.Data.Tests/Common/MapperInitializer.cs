namespace Cinephile.Services.Data.Tests.Common
{
    using System.Reflection;

    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Categories;
    using Cinephile.Web.ViewModels.Comments;
    using Cinephile.Web.ViewModels.Posts;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CommentEditModel).GetTypeInfo().Assembly,
                typeof(PostViewModel).GetTypeInfo().Assembly,
                typeof(CategoryViewModel).GetTypeInfo().Assembly);
        }
    }
}
