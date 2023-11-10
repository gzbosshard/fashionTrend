using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fashionTrend.Domain.Entities;
using fashionTrend.Domain.Enuns;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {


    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Service>()
             .Ignore(s => s.Materials);

        modelBuilder.Entity<Service>()
                 .Ignore(s => s.SewingMachines);

        modelBuilder.Entity<Supplier>()
             .Ignore(s => s.Materials);

        modelBuilder.Entity<Supplier>()
                 .Ignore(s => s.SewingMachines);



        base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceContract> ServiceContracts { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }

}
