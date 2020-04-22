namespace Cinephile.Services.Data
{
    using Cinephile.Web.ViewModels.Actors;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IActorsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task Create(ActorCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(ActorEditModel input);

        Task Delete(ActorEditModel input);
    }
}
