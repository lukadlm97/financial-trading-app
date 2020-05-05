﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.EntityFramework
{
    public class SimpleTraderDbContextFactory : IDesignTimeDbContextFactory<SimpleTraderDbContext>
    {
        public SimpleTraderDbContext CreateDbContext(string[] args=null)
        {
            var options = new DbContextOptionsBuilder<SimpleTraderDbContext>();
            options.UseSqlServer(@"Server = (localdb)\MSSQLLocalDB; Database = Simple_Trader_Dev; Trusted_Connection = True; MultipleActiveResultSets = true");

            return new SimpleTraderDbContext(options.Options);
        }
    }
}
