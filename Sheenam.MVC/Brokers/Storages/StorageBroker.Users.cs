using Microsoft.EntityFrameworkCore;
using Sheenam.MVC.Models.Users;

namespace Sheenam.MVC.Brokers.Storages
{
    public partial class StorageBroker
    {
        public DbSet<User> Users { get; set; }
    }
}
