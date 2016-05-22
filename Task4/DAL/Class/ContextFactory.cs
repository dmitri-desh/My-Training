using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class ContextFactory : IDataContextFactory<Model.ModelContainer>
    {
        public Model.ModelContainer ContextObject
        {
            get { return new Model.ModelContainer(); }
        }
    }
}