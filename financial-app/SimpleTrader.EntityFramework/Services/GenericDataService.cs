using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Service;
using SimpleTrader.EntityFramework.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<T> : IDataService<T> where T:DomainObject
    {
        private readonly SimpleTraderDbContextFactory _context;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(SimpleTraderDbContextFactory context)
        {
            _context = context;
            _nonQueryDataService = new NonQueryDataService<T>(context);
        }
        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(int id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();

                return entities;
            }
        }

        public async Task<T> GetById(int id)
        {
            using (SimpleTraderDbContext context = _context.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                
                return entity;
            }
        }

        public async Task<T> Update(int id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
