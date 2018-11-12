using System.Collections.Generic;


namespace EASV.PetRestAPI.Data
{
    public interface IUserRepository<T>
    {
        IEnumerable<T> GetAll();
        T Get(long id);
        void Add(T entity);
        void Edit(T entity);
        void Remove(long id);
    }
}