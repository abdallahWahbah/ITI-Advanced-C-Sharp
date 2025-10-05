using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_1_generic_interface_Extension_method_Equals
{
    static class ListExtension
    {
        // Extension method >>> using "this" so as to use the function outside class without ClassName.StaticMethod(param)
        // by using the param variable.Function() and not passing the param
        public static void Print(this int x)
        {
            Console.WriteLine("2222222222222222");
        }
        public static List<int> MyFindAll(this List<int> list, Predicate<int> condition) // FunC<int, bool> ::: the same as Predicate<int>
        {
            var res = new List<int>();
            foreach(var item in list)
            {
                if (condition.Invoke(item)) res.Add(item);
            }
            return res;
        }
    }
}
