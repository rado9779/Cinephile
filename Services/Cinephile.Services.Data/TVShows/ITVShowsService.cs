namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.TVShows;

    public interface ITVShowsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllByQuery<T>(string input);

        Task Create(TVShowsCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(TVShowsEditModel input);

        Task Delete(TVShowsEditModel input);

        IEnumerable<T> GetTVShowsForPage<T>(int? take = null, int skip = 0);

        int GetTVShowsCount();

        IEnumerable<T> GetAllGenres<T>(int? count = null);
    }
}
