using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FileSystemBAL.Zone.Models;
using FileSystemBAL.Division.Models;
using FileSystemUtility.Models;

namespace FileSystemBAL.Data
{
    public class DatabaseContext:IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>Options):base(Options)
        {

        }
        public DbSet<Zone.Models.Zone> Zones { get; set; }
        public DbSet<ZoneListResult> ZoneListResult { get; set; }
        public DbSet<Division.Models.Division> Division { get; set; }
        public DbSet<DivisionListResult> DivisionListResult { get; set; }
        public DbSet<Select2> Select2 { get; set; }

        protected override void OnModelCreating(ModelBuilder foModelbuilder)
        {
            foModelbuilder.Entity<ZoneListResult>().HasNoKey();
            foModelbuilder.Entity<Zone.Models.Zone>().HasNoKey();
            foModelbuilder.Entity<Division.Models.Division>().HasNoKey();
            foModelbuilder.Entity<DivisionListResult>().HasNoKey();
            foModelbuilder.Entity<Select2>().HasNoKey();
            base.OnModelCreating(foModelbuilder);
        }
    }
    


}
