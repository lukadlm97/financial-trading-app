using Microsoft.EntityFrameworkCore;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    class SimpleTraderDbContext:DbContext
    {
        DbSet<User> Users;
        DbSet<Account> Accounts;
        DbSet<AssetTransaction> AssetTransactions;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssetTransaction>().OwnsOne(a => a.Stock);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = Simple_Trader_Dev; Trusted_Connection = True; MultipleActiveResultSets = true");

            base.OnConfiguring(optionsBuilder);
        }
    }
}
