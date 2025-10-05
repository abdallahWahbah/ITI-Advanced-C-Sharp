using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegates
{
    internal class Sorting
    {
        private static void Swap<T> (ref T x, ref T y)
        {
            T temp;
            temp = x;
            x = y;
            y = temp;
        }
        public static void SortInt(int[] arr, DelegateBoolean delegate1) // bubble sort 
        {
        // >>> you can use Func<int, int, bool> instead of "DelegateBoolean delegate1"
            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - 1; j++)
                {
                    //if (arr[j] > arr[j + 1])
                    //    Swap(ref arr[j], ref arr[j + 1]);
                    if (delegate1.Invoke(arr[j], arr[j + 1])) // asc, des
                        Swap(ref arr[j], ref arr[j + 1]);
                }
            }
        }
    }
}
