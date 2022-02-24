using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace FileSystemBAL.Data
{
    public class DatabaseContext:IdentityDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext>Options):base(Options)
        {

        }
       
        protected override void OnModelCreating(ModelBuilder foModelbuilder)
        {
           
            base.OnModelCreating(foModelbuilder);
        }
    }
    


}
