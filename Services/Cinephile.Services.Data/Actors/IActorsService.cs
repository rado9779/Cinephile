namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.Actors;

    public interface IActorsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        IEnumerable<T> GetAllByQuery<T>(string input);

        Task Create(ActorCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(ActorEditModel input);

        Task Delete(ActorEditModel input);

        IEnumerable<T> GetByActorsForPage<T>(int? take = null, int skip = 0);

        int GetActorsCount();
    }
}
