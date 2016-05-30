using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DAL
{
    public class CustomerRepository<DTO, Entity, Context> : GenericDALRepository<DTO, Entity, Context>
        where DTO : class
        where Entity : class
        where Context : System.Data.Entity.DbContext
    {
        private Context _context;

        public CustomerRepository(IDataContextFactory<Context> factory) : base(factory)
        {
            _context = factory.ContextObject;
           
        }
        public void AddContext()
        {
            var connectStr = System.Configuration.ConfigurationManager.ConnectionStrings["AppContext"].ToString();
            var context = new System.Data.Entity.DbContext(connectStr);
            
            context.SaveChanges();
        }
                
        public override Entity ToEntity(DTO source)
        {
            throw new NotImplementedException();
        }
    }
}