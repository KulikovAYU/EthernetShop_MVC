using System.Data.Entity;
using GameStore.Domain.Entities;

namespace GameStore.Domain.EMDB.Repositories.DBContext
{
    public class EFDbContext : DbContext
    {
        public DbSet<Game> Games { get; set; }

        public EFDbContext(string connectionString) : base(nameOrConnectionString: connectionString)
        { }

        public EFDbContext()
        {
        }
    }
}