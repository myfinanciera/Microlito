using System;
using Microsoft.EntityFrameworkCore;
using Siigo.Core.Provider.Context;
using Siigo.Microservice.Domain.Aggregates.Bank.Entities;

namespace Siigo.Microservice.Infrastructure.Contexts;

public sealed class SqlServerContext : DbContextBase
{
    public SqlServerContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
    {
    }


    public DbSet<Bank> Bank { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Bank>().HasKey(bank => bank.BankID);
        //modelBuilder
        //    .Entity<Bank>()
        //    .Property(d => d.BankID)
        //    .ValueGeneratedOnAdd();
        
        //modelBuilder
        //    .Entity<Bank>()
        //    .Ignore(x=>x.TenantID);

            
        base.OnModelCreating(modelBuilder);
    }
}