using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public interface IRepository<DTO, Entity> : IDisposable
    {
        void Add(DTO obj);
        void Remove(DTO obj);
        void Update(DTO obj);
        IEnumerable<DTO> GetAll();
        IEnumerable<DTO> FirstOrDefault(Expression<Func<DTO, bool>> condition);
        IEnumerable<DTO> GetMany(Expression<Func<DTO, bool>> condition);
        void SaveChanges();
        Entity ToEntity(DTO source);
    }
}