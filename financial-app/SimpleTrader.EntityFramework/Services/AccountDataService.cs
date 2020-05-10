using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService:IDataService<Account>
    {
        private readonly SimpleTraderDbContextFactory _context;

        public AccountDataService(SimpleTraderDbContextFactory context)
        {
            _context = context;
        }

        public async Task<Account> Create(Account entity)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                EntityEntry<Account> createdResult = await context.Set<Account>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdResult.Entity;
            }
        }

        public async Task<bool> Delete(int id)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                Account entity = await context.Set<Account>().FirstOrDefaultAsync((e) => e.Id == id);
                context.Set<Account>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                IEnumerable<Account> entities = await context.Accounts.Include(a => a.AssetTransactions).ToListAsync();
                
                return entities;
            }
        }

        public async Task<Account> GetById(int id)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                User u = await context.Users.FirstOrDefaultAsync(u => u.Id == id);

                Account entity = await context.Accounts
                    .Include(a=> a.AssetTransactions)
                    .FirstOrDefaultAsync(a => a.Id==id);
                
                return entity;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                entity.Id = id;
                context.Set<Account>().Update(entity);
                await context.SaveChangesAsync();

                return entity;
            }
        }
    }
}
