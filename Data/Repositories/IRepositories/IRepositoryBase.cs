namespace  Data.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
         void  Add(T entity); 
        void Update(T entity);
        void Delete(T entity);
        T Get(int id);
        IEnumerable<T> GetAll();

    }
}
