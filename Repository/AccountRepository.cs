using Data.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public  class AccountRepository : IRepository<Cuenta>
    {
        private readonly ApiRestDbManuelRojasContext _dbContext;

        public AccountRepository(ApiRestDbManuelRojasContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public void Add(Cuenta entity)
        {
            _dbContext.Entry(entity).State = EntityState.Added;
            _dbContext.Cuentas.Add(entity);
            _dbContext.SaveChanges();
        }

        public IEnumerable<Cuenta> GetAll()
        {
            return _dbContext.Cuentas.ToList();
        }

        public Cuenta GetById(int id)
        {
            return _dbContext.Cuentas.Find(id);
        }

        public void Remove(int id)
        {
            Cuenta? cuenta = _dbContext.Cuentas.Find(id);

            if (cuenta != null)
            {
                _dbContext.Entry(cuenta).State = EntityState.Deleted;
                _dbContext.Cuentas.Remove(cuenta);
                _dbContext.SaveChanges();
            }
        }

        public void Update(Cuenta entity)
        {
            _dbContext.Entry(entity).State= EntityState.Modified;
            _dbContext.Cuentas.Update(entity);
            _dbContext.SaveChanges();
        }
    }
}
