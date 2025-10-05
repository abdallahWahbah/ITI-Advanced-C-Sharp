using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_1_generic_interface_Extension_method_Equals
{
    internal interface IOperation<T>
    {
        T Add(T item1, T item2);
    }
    class ABC: IOperation<int>, IOperation<string> // now you must implement "Add" 2 times, first for "int", second for "string
    {
        public int Add(int x, int y)
        {
            return x + y;
        }
        public string Add(string x, string y)
        {
            return "Hello: " + x + y;
        }
    }
}
