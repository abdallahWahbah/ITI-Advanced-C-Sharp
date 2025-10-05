using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16_delegates_
{
    internal class Sorting
    {
        // this class is called "publisher" :::: the class at which something (event) will happen
        public event Func<int, int, bool> myDelegate; // event
        private static void Swap<T> (ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        public void SortInt(int[] arr) 
        {
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    if (myDelegate.Invoke(arr[j], arr[j + 1])) // fire event
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }
    }
}
