using Data.SqlServer.Context;
using Domain.Core.Models;
using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Data.SqlServer.Repositories
{ 
    public class RepositoryBase<Entity> : IRepository<Entity> where Entity : class
    {
        private readonly CadCenterContext _context;
        protected DbSet<Entity> DbSet;
        public RepositoryBase(CadCenterContext context)
        {
            _context = context;
            DbSet = _context.Set<Entity>();

        }
        public void Create(Entity entity)
        {
            DbSet.Add(entity);  
        }

        public void Delete(Entity entity)
        {
            DbSet.Remove(entity);
        }
         
        public async Task<List<Entity>> Get(Expression<Func<Entity, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }

        public async Task<List<Entity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public Entity? GetById(Guid Id)
        {
            return DbSet.Find(Id);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void Update(Entity entity)
        {
            DbSet.Update(entity);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
         
    }
}
