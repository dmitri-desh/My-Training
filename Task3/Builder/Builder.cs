using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    abstract class Builder
    {
        public abstract void Initialize();
        public abstract void ReadFile();
        public abstract void GetResult();

    }
}
