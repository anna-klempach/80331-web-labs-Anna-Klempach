using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebLabs_Klempach.DAL.Entities;

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
