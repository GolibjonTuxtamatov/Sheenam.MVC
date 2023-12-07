using EFxceptions;
using Microsoft.EntityFrameworkCore;

namespace Sheenam.MVC.Brokers.Storages
{
    public partial class StorageBroker : EFxceptionsContext
    {
        private readonly IConfiguration configuration;

        public StorageBroker(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "Data Source = ./Data/Sheenam.db";
            optionsBuilder.UseSqlite(connectionString);
        }

        public override void Dispose() { }
    }
}
