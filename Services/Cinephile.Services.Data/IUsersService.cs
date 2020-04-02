namespace Cinephile.Services.Data
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        IEnumerable<T> GetAllUserPosts<T>(string userId);
    }
}
