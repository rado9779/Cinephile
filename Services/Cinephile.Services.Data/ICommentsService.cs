namespace Cinephile.Services.Data
{
    using System.Threading.Tasks;

    public interface ICommentsService
    {
        Task Create(int postId, string userId, string content);
    }
}
