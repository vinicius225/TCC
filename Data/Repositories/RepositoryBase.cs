using Data.Repositories.Interfaces;
using System.Data.Entity.Core;

namespace Data.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {

        readonly AppDbContext _appDbContext ;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public void Add(T entity)
        {
            _appDbContext.Add(entity);
            _appDbContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            _appDbContext.Remove(entity);
            _appDbContext.SaveChanges();
        }

        public  T Get(int id)
        {
            return  _appDbContext.Set<T>().Find(id);
        }

        public   IEnumerable<T> GetAll()
        {

                return  _appDbContext.Set<T>();
        }

        public void Update(T entity)
        {
            _appDbContext.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();
        }
    }
}
