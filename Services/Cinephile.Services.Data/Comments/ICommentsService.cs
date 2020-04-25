namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.Comments;

    public interface ICommentsService
    {
        T GetById<T>(int id);

        IEnumerable<T> GetAll<T>(int? count = null);

        Task Create(int postId, string userId, string content);

        Task Edit(CommentEditModel input);

        Task Delete(CommentEditModel input);

        IEnumerable<T> GetByPostId<T>(int postId, int? take = null, int skip = 0);

        int GetCountByPostId(int postId);
    }
}
