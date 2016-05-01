using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2;

namespace TextBuilder1
{
    sealed class CustomTextBuilder : Builder
    {
        
        private Text text;
        private SeparatorContainer separatorContainer;
        private Parser parser;
        public override void Initialize()
        {
           
            Console.WriteLine("Initialize");
            text = new Text();
            separatorContainer = new SeparatorContainer();
            parser = new Parser(separatorContainer);
        }
        public override void ReadFile()
        {
            var fileName = ConfigurationManager.AppSettings["pathToSourceFile"];
            StreamReader reader = null;
            try
            {
                reader = File.OpenText(fileName);
                text = parser.Parse(reader);
            }
            catch (IOException e)
            {
                Console.WriteLine("Error reading. {0}", e.Message);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
        public override void BuildPartC()
        {
          
        }
        public override void GetResult()
        {
            text.Sentences.GetEnumerator();
            
        }
    }
}
