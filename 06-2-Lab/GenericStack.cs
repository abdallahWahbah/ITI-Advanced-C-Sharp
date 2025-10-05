namespace _06_2_Lab
{
    internal class GenericStack<T>: IDisposable where T: IComparable<T>
    {
        T[] myArr;
        int tos;
        public int Size { get; private set; }

        public GenericStack(int _size)
        {
            Size = _size;
            tos = -1;
            myArr = new T[_size];
        }
        public bool IsFull() => tos == Size - 1;
        public bool IsEmpty() => tos == -1;
        private void Resize()
        {
            Size *= 2;
            T[] newArr = new T[Size];
            for (int i = 0; i <= tos; i++)
                newArr[i] = myArr[i];

            myArr = newArr;
        }
        public void Push(T item)
        {
            //if (IsFull()) throw new IndexOutOfRangeException();
            if (IsFull()) Resize();
            tos++;
            myArr[tos] = item;
        }
        public T Pop()
        {
            if (IsEmpty()) throw new Exception("Stack is empty, cannot Pop!");

            T currentLastItem = myArr[tos];
            tos--;
            return currentLastItem;
        }
        public T Peek()
        {
            if(IsEmpty()) throw new Exception("Stack is empty, cannot Peek!");
            return myArr[tos];
        }
        public T GetItemAtIndex(int i)
        {
            if(!IsEmpty() && i <= tos && i >= 0) return myArr[i];
            throw new Exception($"Invalid index {i}. Current top is {tos}.");
        }
        public bool RemoveByValue(T element)
        {
            for(var i = 0; i <= tos; i++)
            {
                if(myArr[i].CompareTo(element) == 0)
                {
                    for (var j = i; j < tos; j++)
                    {
                        myArr[j] = myArr[j + 1];
                    }
                    tos--;
                    return true;
                }
            }
            return false;
        }
        // Indexer
        public T this[int i]
        {
            get
            {
                if(i < 0 || i > tos) throw new Exception("Invalid index in stack (Indexer - Get).");
                return myArr[i];
            }
            set
            {
                if(i < 0 || i > tos) throw new Exception("Invalid index in stack (Indexer - Set).");
                myArr[i] = value;
            }
        }
        public void Dispose()
        {
            Console.WriteLine("Cleaning Up resources from the memory");
        }
    }
}
