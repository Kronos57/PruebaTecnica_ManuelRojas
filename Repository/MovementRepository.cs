using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class MovementRepository : IRepository<Movimiento>
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public MovementRepository(ApiRestDbManuelRojasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Movimiento entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Movimientos.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Movimiento> GetAll()
        {
            return _dbContext.Movimientos.ToList();
        }

        public Movimiento GetById(int id)
        {
            return _dbContext.Movimientos.Find(id);
        }

        public void Remove(int id)
        {
            Movimiento? movimiento = _dbContext.Movimientos.Find(id);

            if (movimiento != null)
            {
                _dbContext.Entry(movimiento).State = EntityState.Deleted;
                _dbContext.Movimientos.Remove(movimiento);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Movimiento entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Movimientos.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
