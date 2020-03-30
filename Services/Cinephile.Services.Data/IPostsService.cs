namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IPostsService
    {
        Task<int> Create(string title, string content, int categoryId, string userId);

        T GetById<T>(int id);

        IEnumerable<T> GetAll<T>(int? count = null);
    }
}
