using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using PhotoAlbum.DAL.EF.Interfaces.IRepository;

namespace PhotoAlbum.DAL.EF.Repositories.Base
{
    public class BaseRepository<T> : IRepository<T>, IDisposable where T : class
    {
        protected PhotoAlbumContext _context;
        protected DbSet<T> _dbSet { get; }

        protected bool isDisposed = false;

        public BaseRepository(PhotoAlbumContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T GetById(int? id)
        {
            return _dbSet.Find(id);
        }

        public void Update(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).AsEnumerable();
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int? id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public void Create(T item)
        {
            _dbSet.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int itemId)
        {
            var item = _dbSet.Find(itemId);
            _dbSet.Remove(item);
            _context.SaveChanges();

        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
