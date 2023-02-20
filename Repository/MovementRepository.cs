using Data.EntityFramework.Entities;

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
            throw new NotImplementedException();
        }

        public IEnumerable<Movimiento> GetAll()
        {
            throw new NotImplementedException();
        }

        public Movimiento GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Movimiento entity)
        {
            throw new NotImplementedException();
        }
    }
}
