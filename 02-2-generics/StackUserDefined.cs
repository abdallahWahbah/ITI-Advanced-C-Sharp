using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_2_generics
{
    internal class StackUserDefined<T>
    {
        T[] arr;
        int Size { get; }
        int tos;

        public StackUserDefined(int _size = 5)
        {
            Size = _size;
            tos = -1;
            arr = new T[_size];
        }
        public bool IsFull() => tos == Size - 1;
        public bool IsEmpty() => tos == -1;
        public void Push(T num)
        {
            if (IsFull()) throw new NotImplementedException();
            tos++;
            arr[tos] = num;
        }
        public T Pop()
        {
            if (!IsEmpty())
            {
                T d = arr[tos];
                tos--;
                return d;
            }
            throw new NotImplementedException();
        }
    }
}
