namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllByQuery<T>(string input);

        IEnumerable<T> GetAllByGenre<T>(string genre);

        Task Create(MovieCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(MovieEditModel input);

        Task Delete(MovieEditModel input);

        IEnumerable<T> GetByMoviesForPage<T>(int? take = null, int skip = 0);

        int GetMoviesCount();

        IEnumerable<T> GetAllGenres<T>(int? count = null);
    }
}
