namespace z_test
{
    public class GenericStack<T> where T: class, IComparable<T>
    {
        T[] arr;
        public int Size { get; private set; }
        int tos;
        public GenericStack(int _size)
        {
            Size = _size;
            tos = -1;
            arr = new T[_size];
        }
        public bool IsFull() => tos == Size - 1;
        public bool IsEmpty() => tos == -1;
        private void Resize()
        {
            Size *= 2;
            T[] newArr = new T[Size];
            for (int i = 0; i <= tos; i++)
                newArr[i] = arr[i];

            arr = newArr;
        }
        public void Push(T item)
        {
            if (IsFull()) return;
            tos++;
            arr[tos] = item;
        }
        public T Pop()
        {
            if (IsEmpty()) throw new Exception();
            T item = arr[tos];
            tos--;
            return item;
        }

        public T this[int i]
        {
            get
            {
                if (i > tos || i < 0) throw new IndexOutOfRangeException();
                return arr[i];
            }
            set
            {
                if(i > tos || i < 0) throw new IndexOutOfRangeException();
                arr[i] = value;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
