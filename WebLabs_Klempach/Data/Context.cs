using Microsoft.EntityFrameworkCore;

namespace WebLabs_Klempach.Data
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<WebLabs_Klempach.DAL.Entities.Loot> Loot { get; set; }
    }
}
