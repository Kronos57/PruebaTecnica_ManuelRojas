using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IClientRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente entity);
        void Update(Cliente entity);
        void Remove(int id);
    }
}
