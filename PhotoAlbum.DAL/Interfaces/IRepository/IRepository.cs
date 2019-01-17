using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PhotoAlbum.DAL.Interfaces.IRepository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int? id);
        IEnumerable<T> GetAll(Expression<Func<T, bool>> predicate);
        T GetSingle(Expression<Func<T, bool>> predicate);

        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate);

        void Create(T item);
        void Update(T item);
        void Delete(int itemId);
    }
}
