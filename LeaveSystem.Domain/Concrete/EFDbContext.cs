using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LeaveSystem.Domain.Entities;
using System.Data.Entity;

namespace LeaveSystem.Domain.Concrete
{
    public class EFDbContext:DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
