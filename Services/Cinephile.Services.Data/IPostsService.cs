namespace Cinephile.Services.Data
{
    using Cinephile.Web.ViewModels.Posts;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> Create(string title, string content, int categoryId, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetByCategoryId<T>(int categoryId, int? take = null, int skip = 0);

        int GetCountByCategoryId(int categoryId);

        IEnumerable<T> GetByTitle<T>(string title);

        Task Edit(PostEditViewModel input);
    }
}
