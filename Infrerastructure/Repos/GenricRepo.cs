using Core.Entites;
using Core.Helpers;
using Core.Interfaces;
using Infrerastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrerastructure.Repos
{
    public class GenricRepo<T> : IGenricRepo<T> where T : BaseEntity
    {
        private readonly StoreContext db;

        public GenricRepo(StoreContext db)
        {
            this.db = db;
        }

        public async Task<T> GetByFilterAsync(IHelpers<T> Help)
        {
            return await CallHelpers(Help).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int Id)
        {
            return await db.Set<T>().FindAsync(Id);

        }

        public async Task<int> GetCountAsync(IHelpers<T> Help)
        {
           return await CallHelpers(Help).CountAsync();
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await db.Set<T>().ToListAsync();

        }

        public async Task<IReadOnlyList<T>> listAllByFilterAsync(IHelpers<T> Help)
        {
            return await CallHelpers(Help).ToListAsync();
        }

        private IQueryable<T> CallHelpers(IHelpers<T> help)
        {
            return HelpersCall<T>.GetQuery(db.Set<T>().AsQueryable(), help);
        }
    }
}
