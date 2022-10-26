using Microsoft.EntityFrameworkCore;
using RaqamliAvlod.Domain.Entities.Contests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaqamliAvlod.DataAccess.DbContexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Contest> Contests { get; set; } = null!;
    }
}
