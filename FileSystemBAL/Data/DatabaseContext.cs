﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FileSystemBAL.Zone.Models;
using FileSystemBAL.Division.Models;
using FileSystemUtility.Models;
using FileSystemBAL.Room.Models;
using FileSystemBAL.Almirah.Models;
using FileSystemBAL.Shelve.Models;

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
        public DbSet<Department.Models.Department> Department { get; set; }
        public DbSet<Department.Models.DepartmentListResult> DepartmentListResult { get; set; }
        public DbSet<Designation.Models.Designation> Designation { get; set; }
        public DbSet<Designation.Models.DesignationListResult> DesignationListResult { get; set; }
        public DbSet<User.Models.UserEmailResult> UserEmailResult { get; set; }
        public DbSet<Desk.Models.Desk> Desk { get; set; }
        public DbSet<Desk.Models.DeskListResult> DeskListResult { get; set; }
        public DbSet<Store.Models.Store> Store { get; set; }
        public DbSet<Store.Models.StoreListResult> StoreListResult { get; set; }
        public DbSet<Room.Models.Room> Room { get; set; }
        public DbSet<RoomListResult> RoomListResult { get; set; }
        public DbSet<Almirah.Models.Almirah> Almirah { get; set; }
        public DbSet<AlmirahListResult> AlmirahListResult { get; set; }
        public DbSet<Shelve.Models.Shelve> Shelve { get; set; }
        public DbSet<ShelveListResult> ShelveListResult { get; set; }
        public DbSet<Select2> Select2 { get; set; }

        protected override void OnModelCreating(ModelBuilder foModelbuilder)
        {
            foModelbuilder.Entity<ZoneListResult>().HasNoKey();
            foModelbuilder.Entity<Zone.Models.Zone>().HasNoKey();
            foModelbuilder.Entity<Division.Models.Division>().HasNoKey();
            foModelbuilder.Entity<DivisionListResult>().HasNoKey();
            foModelbuilder.Entity<Department.Models.DepartmentListResult> ().HasNoKey();
            foModelbuilder.Entity<Department.Models.Department> ().HasNoKey();
            foModelbuilder.Entity<Designation.Models.Designation>().HasNoKey();
            foModelbuilder.Entity<Designation.Models.DesignationListResult>().HasNoKey();
            foModelbuilder.Entity<Select2>().HasNoKey();
            foModelbuilder.Entity<User.Models.UserEmailResult>().HasNoKey();
            foModelbuilder.Entity<Desk.Models.Desk>().HasNoKey();
            foModelbuilder.Entity<Desk.Models.DeskListResult>().HasNoKey();
            foModelbuilder.Entity<Store.Models.Store>().HasNoKey();
            foModelbuilder.Entity<Store.Models.StoreListResult>().HasNoKey();
            foModelbuilder.Entity<Room.Models.Room>().HasNoKey();
            foModelbuilder.Entity<RoomListResult>().HasNoKey();
            foModelbuilder.Entity<Almirah.Models.Almirah>().HasNoKey();
            foModelbuilder.Entity<AlmirahListResult>().HasNoKey();
            foModelbuilder.Entity<Shelve.Models.Shelve>().HasNoKey();
            foModelbuilder.Entity<ShelveListResult>().HasNoKey();
            base.OnModelCreating(foModelbuilder);
        }
    }
    


}
