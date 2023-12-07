using Microsoft.EntityFrameworkCore;
using Sheenam.MVC.Models.Users;

namespace Sheenam.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }

        public async ValueTask<User> InsertUserAsync(User user) =>
            await InsertAsync(user);
    }
}
