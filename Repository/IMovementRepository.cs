using Data.EntityFramework.Entities;

namespace Repository
{
    public interface IMovementRepository
    {
        IEnumerable<Movimiento> GetAll();
        Movimiento GetById(int id);
        void Add(Movimiento entity);
        void Update(Movimiento entity);
        void Remove(int id);
    }
}
