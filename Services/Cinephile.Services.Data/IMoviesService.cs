namespace Cinephile.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.Movies;

    public interface IMoviesService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task Create(MovieCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(MovieEditModel input);

        Task Delete(MovieEditModel input);
    }
}
