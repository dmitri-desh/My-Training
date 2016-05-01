using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace TextBuilder1
{
    abstract class Builder
    {
       // Product product = new Product();

        public abstract void Initialize();
        public abstract void ReadFile();
        public abstract void BuildPartC();
        public abstract void GetResult();
    }
}
