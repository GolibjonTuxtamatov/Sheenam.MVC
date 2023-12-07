using Sheenam.MVC.Models.Users;

namespace Sheenam.MVC.Brokers.Storages
{
    public partial interface IStorageBroker
    {
        ValueTask<User> InsertUserAsync(User user);
    }
}
