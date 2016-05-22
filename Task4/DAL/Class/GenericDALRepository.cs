using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    internal abstract class GenericDALRepository<DTO, Entity, Context> : IRepository<DTO, Entity>
        where DTO : class
        where Entity : class
        where Context : System.Data.Entity.DbContext
    {
        protected Context _context;
        public GenericDALRepository(IDataContextFactory<Context> factory)
        {
            _context = factory.ContextObject;
        }
        public void Add(DTO obj)
        {
            Entity entity = ToEntity(obj);
            var temp = _context.Set<Entity>().Attach(entity);
            if (temp != null)
            {
                _context.Entry<Entity>(temp).State = System.Data.Entity.EntityState.Detached;
            }
            else
            {
                _context.Set<Entity>().Add(entity);
            }
        }
        public void Update(DTO obj)
        {
            Entity entity = ToEntity(obj);
            
            if (entity != null)
            {
                _context.Entry<Entity>(entity).State = System.Data.Entity.EntityState.Modified;
            }
            
        }
        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public IEnumerable<DTO> FirstOrDefault(Expression<Func<DTO, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DTO> GetMany(Expression<Func<DTO, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public void Remove(DTO obj)
        {
            Entity entity = ToEntity(obj);
            var temp = _context.Set<Entity>().Attach(entity);
            if (temp != null)
            {
                _context.Entry<Entity>(temp).State = System.Data.Entity.EntityState.Detached;
            }
            else
            {
                _context.Set<Entity>().Remove(entity);
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public abstract Entity ToEntity(DTO source);
        
        ~GenericDALRepository()
        {
            if (_context != null)
            {
                Dispose();
            }
        }
    }
}