using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class PersonRepository : IRepository<Persona>
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public PersonRepository(ApiRestDbManuelRojasContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Persona entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Personas.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Persona> GetAll()
        {
            return _dbContext.Personas.ToList();
        }

        public Persona GetById(int id)
        {
            return _dbContext.Personas.Find(id);
        }

        public void Remove(int id)
        {
            Persona? persona = _dbContext.Personas.Find(id);

            if (persona != null)
            {
                _dbContext.Entry(persona).State = EntityState.Deleted;
                _dbContext.Personas.Remove(persona);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Persona entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.Personas.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
