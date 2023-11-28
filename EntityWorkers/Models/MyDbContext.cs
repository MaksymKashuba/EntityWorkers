using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EntityWorkers.Models;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public DbSet<Worker> Workers { get; set; }

    public DbSet<WorkersCity> WorkersCities { get; set; }

    public DbSet<WorkersCountry> WorkersCountries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=MaksymNotebook;Database=MyDB;Trusted_Connection=True;TrustServerCertificate=True");
}
