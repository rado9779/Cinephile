namespace Cinephile.Services.Data.Tests.Common
{
    using System;

    using Cinephile.Data;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContextCreatorInMemory
    {
        public static ApplicationDbContext InitializeContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new ApplicationDbContext(options);
        }
    }
}
