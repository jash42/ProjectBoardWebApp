using Microsoft.EntityFrameworkCore;
using ProjectBoardWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.Data
{
    public class WorkTaskDbContext : DbContext
    {
        public WorkTaskDbContext(DbContextOptions<WorkTaskDbContext> options)
            : base(options)
        {
        }

        public DbSet<WorkTask> WorkTask { get; set; }

    }
}
