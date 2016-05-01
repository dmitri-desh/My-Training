using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class Text  
    {
        public ICollection<ISentence> Sentences { get; set; }
        public Text()
        {
            Sentences = new List<ISentence>();
        
        }
        
    }
}
