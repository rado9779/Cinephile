﻿namespace Cinephile.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Cinephile.Web.ViewModels.TVShows;

    public interface ITVShowsService
    {
        IEnumerable<T> GetAll<T>(int? count = null);

        Task Create(TVShowsCreateModel input);

        T GetByTitle<T>(string title);

        T GetById<T>(int id);

        Task Edit(TVShowsEditModel input);

        Task Delete(TVShowsEditModel input);
    }
}