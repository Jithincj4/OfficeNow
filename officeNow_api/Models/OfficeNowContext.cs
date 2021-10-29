using System;
using Microsoft.EntityFrameworkCore;

namespace officeNow_api.Models
{
    public class OfficeNowContext:DbContext
    {
        public OfficeNowContext(DbContextOptions<OfficeNowContext> options) : base(options) { }

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Location> CompanyLocations { get; set; }
        public DbSet<WorkStation> WorkStations { get; set; }
        public DbSet<BookingLog> BookingLogs { get; set; }

        public DbSet<UserTags> UserTags { get; set; }
        public DbSet<WorkStationTags> WorkStationTags { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().ToTable("UserRole");
            modelBuilder.Entity<Tags>().ToTable("Tag");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Location>().ToTable("CompanyLocation");
            modelBuilder.Entity<WorkStation>().ToTable("WorkStation");
            modelBuilder.Entity<BookingLog>()
                .ToTable("BookingLog");
                                
            modelBuilder.Entity<UserTags>().ToTable("UserTag");
            modelBuilder.Entity<WorkStationTags>().ToTable("WorkStationTag");

            modelBuilder.Entity<BookingLog>().HasOne(x=>x.BookedUser)
                .WithOne()
                .HasForeignKey<BookingLog>(s=>s.UserId).OnDelete(DeleteBehavior.ClientNoAction);

            modelBuilder.Entity<BookingLog>().HasOne(x=>x.WorkStation)
                .WithOne()
                .HasForeignKey<BookingLog>(s => s.WorkStationId)
                .OnDelete(DeleteBehavior.ClientNoAction);

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.LogTo(Console.WriteLine);
    }
}
