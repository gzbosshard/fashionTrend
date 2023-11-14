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
            .Property(e => e.Materials)
            .HasConversion(
                v => string.Join(",", v.Select(s => s.ToString())), 
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => (Material)Enum.Parse(typeof(Material), s))
                      .ToList());

        modelBuilder.Entity<Service>()
           .Property(e => e.SewingMachines)
           .HasConversion(
               v => string.Join(",", v.Select(s => s.ToString())),
               v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => (SewingMachine)Enum.Parse(typeof(SewingMachine), s))
                     .ToList());

        modelBuilder.Entity<Supplier>()
            .Property(e => e.Materials)
            .HasConversion(
                v => string.Join(",", v.Select(s => s.ToString())),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                      .Select(s => (Material)Enum.Parse(typeof(Material), s))
                      .ToList());

        modelBuilder.Entity<Supplier>()
           .Property(e => e.SewingMachines)
           .HasConversion(
               v => string.Join(",", v.Select(s => s.ToString())),
               v => v.Split(',', StringSplitOptions.RemoveEmptyEntries)
                     .Select(s => (SewingMachine)Enum.Parse(typeof(SewingMachine), s))
                     .ToList());

       

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<ServiceContract> ServiceContracts { get; set; }
    public DbSet<ServiceOrder> ServiceOrders { get; set; }

}
