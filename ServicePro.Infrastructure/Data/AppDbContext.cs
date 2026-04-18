using Microsoft.EntityFrameworkCore;
using ServicePro.Core.DTOs;
using ServicePro.Core.DTOs.outbound;
using ServicePro.Core.Entities;
using ServicePro.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePro.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Alltabledataforlisting> products { get; set; }


        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<OfficeListDto> OfficeList { get; set; }
        public DbSet<CareLog> CareLogs { get; set; }

        public DbSet<CareLogActivity> CareLogActivities { get; set; }
        public DbSet<CarePlanSpResult> CarePlanSpResults { get; set; }
        public DbSet<Compliance> Compliances { get; set; }
        public DbSet<ScheduleSeries> ScheduleSeries { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Categories> Categories { get; set; }



        public DbSet<ComplianceSpResult> ComplianceSpResults { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ScheduleSeries>()
           .HasKey(s => s.SeriesId);

            modelBuilder.Entity<Schedule>()
                .HasKey(s => s.ScheduleId);

            // Relationship: Schedule 1 - * Series
            modelBuilder.Entity<Schedule>()
                .HasMany(s => s.Series)
                .WithOne(s => s.Schedule)
                .HasForeignKey(s => s.ScheduleId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<OfficeListDto>().HasNoKey();
            modelBuilder.Entity<CarePlanSpResult>().HasNoKey();
            modelBuilder.Entity<ComplianceSpResult>().HasNoKey();
            // Product → ProductImages One-To-Many
            modelBuilder.Entity<Product>()
                .HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<CareLogActivity>()
       .HasOne<CareLog>()
       .WithMany(x => x.Activities)
       .HasForeignKey(x => x.CareLogId);
            // Optional: Decimal precision fix
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Product>()
    .Ignore("CategoryId");

        }

    }

}
