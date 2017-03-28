using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionsAndGenerics
{
    class MyEnumerator : IEnumerable<int>
    {
        class RandomEnumerator : IEnumerator<int>
        {
            private Random rand = new Random();
            public int Current
            {
                get
                {
                   return rand.Next(-10, 10000);
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return Current;
                }
            }

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return Current >= 0 ? true : false;
            }

            public void Reset()
            {
               
            }
        }
        public IEnumerator<int> GetEnumerator()
        {
            return new RandomEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
