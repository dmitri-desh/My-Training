using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    interface IDataContextFactory<Context> where Context : System.Data.Entity.DbContext
    {
        Context ContextObject { get; }
    }
}