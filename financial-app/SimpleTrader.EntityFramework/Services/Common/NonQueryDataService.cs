

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services.Common
{
    public class NonQueryDataService<T> where T:DomainObject
    {
        private readonly SimpleTraderDbContextFactory _context;

        public NonQueryDataService(SimpleTraderDbContextFactory context)
        {
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                EntityEntry<T> createdResult = await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                entity.Id = id;
                context.Set<T>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
