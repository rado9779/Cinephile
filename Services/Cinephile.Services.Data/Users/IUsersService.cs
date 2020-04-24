namespace Cinephile.Services.Data
{
    using System.Collections.Generic;

    public interface IUsersService
    {
        T GetUserByName<T>(string name);

        IEnumerable<T> GetAllUserPosts<T>(string username);
    }
}
