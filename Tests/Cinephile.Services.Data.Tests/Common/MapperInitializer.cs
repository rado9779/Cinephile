namespace Cinephile.Services.Data.Tests.Common
{
    using System.Reflection;

    using Cinephile.Services.Mapping;
    using Cinephile.Web.ViewModels.Comments;

    public class MapperInitializer
    {
        public static void InitializeMapper()
        {
            AutoMapperConfig.RegisterMappings(
                typeof(CommentEditModel).GetTypeInfo().Assembly);
        }
    }
}
