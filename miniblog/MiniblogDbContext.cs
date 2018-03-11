using Microsoft.EntityFrameworkCore;
using miniblog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniblog
{
    public class MiniblogDbContext : DbContext
    {
        public MiniblogDbContext(DbContextOptions<MiniblogDbContext> options) : base(options) {
            

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Page> Pages { get; set; }
    }
}
