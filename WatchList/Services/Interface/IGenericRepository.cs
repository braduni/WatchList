using System.Linq.Expressions;

namespace WatchList.Services.Repository
{
    public interface IGenericRepository<T> 
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);   
    }
}