using Microsoft.EntityFrameworkCore;
using StudentPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPortal.Context
{
    public class PortalDbContext : DbContext
    {
        public DbSet<Students> Students { get; set; }

        public PortalDbContext(DbContextOptions<PortalDbContext> options)
           : base(options)
        {
        }
    }
}
