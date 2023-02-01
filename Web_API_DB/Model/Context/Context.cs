using Microsoft.EntityFrameworkCore;

namespace Web_API_DB.Model.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
            //Base constructor
        }

        public DbSet<User> Users { get; set; }
    }
}
