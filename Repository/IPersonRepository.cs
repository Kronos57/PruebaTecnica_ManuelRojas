using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IPersonRepository
    {
        IEnumerable<Persona> GetAll();
        Persona GetById(int id);
        void Add(Persona entity);
        void Update(Persona entity);
        void Remove(int id);
    }
}
