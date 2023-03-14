using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IAccountRepository
    {
        IEnumerable<Cuenta> GetAll();
        Cuenta GetById(int id);
        void Add(Cuenta entity);
        void Update(Cuenta entity);
        void Remove(int id);
    }
}
