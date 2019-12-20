using Microsoft.EntityFrameworkCore;
using ProjectBoardWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBoardWebApp.Data
{
    public class OrgDbContext : DbContext
    {
        public OrgDbContext (DbContextOptions<OrgDbContext> options)
            : base(options)
        {
        }

        public DbSet<Organizations> Organizations {get;set;}
    }
}
