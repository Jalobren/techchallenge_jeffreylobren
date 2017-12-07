using RaceDay.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RaceDay.Entity.Repositories
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal RaceDayContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(RaceDayContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public DbSet<TEntity> GetDbSet()
        {
            return _dbSet;
        }

        public IEnumerable<TEntity> All()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate)
        {
            IEnumerable<TEntity> results = _dbSet.AsNoTracking()
                .Where(predicate).ToList();
            return results;
        }
    }
}
