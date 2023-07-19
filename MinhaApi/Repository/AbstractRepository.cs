using Microsoft.EntityFrameworkCore;
using MinhaApi.Data;
using ProductsAPI.Repository.Interfaces;
using System.Linq.Expressions;

namespace ProductsAPI.Repository
{
    public class AbstractRepository<T> : IAbstractRepository<T> where T : class
    {
        protected ProductDBContext _context;

        public AbstractRepository(ProductDBContext context)
        {
            _context = context;
        }

        public IQueryable<T> Get()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }
    }
}
