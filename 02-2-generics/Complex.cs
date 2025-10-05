using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_2_generics
{
    internal class Complex : IComparable
    {
        public int Real { get; set; }
        public int Img { get; set; }

        public int CompareTo(object? obj)
        {
            return 1;
        }

        public override string ToString()
        {
            return $"{Real} + {Img}j";
        }
    }
}
