using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using SimpleTrader.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class AccountDataService:IDataService<Account>
    {
        private readonly SimpleTraderDbContextFactory _context;

        public NonQueryDataService<Account> _nonQueryDataService;

        public AccountDataService(SimpleTraderDbContextFactory context)
        {
            _context = context;
            _nonQueryDataService = new NonQueryDataService<Account>(context);
        }

        public async Task<Account> Create(Account entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
            
        }

        public async Task<IEnumerable<Account>> GetAll()
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                var entities = await context.Accounts.Include(a=>a.AssetTransactions).ToListAsync();
                
                return entities;
            }
        }

        public async Task<Account> GetById(int id)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
              

                Account entity = await context.Accounts
                    .Include(a=> a.AssetTransactions)
                    .FirstOrDefaultAsync(e => e.Id==id);
                
                return entity;
            }
        }

        public async Task<Account> Update(int id, Account entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
