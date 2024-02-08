using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<Entity> : IDisposable where Entity : class
    {
        Task<List<Entity>> Get(Expression<Func<Entity, bool>> predicate);
        Task<List<Entity>> GetAll();
        Entity? GetById(Guid Id); 
        void Create(Entity endereco);
        void Update(Entity endereco);
        void Delete(Entity entity);
        int SaveChanges();
    }
}
