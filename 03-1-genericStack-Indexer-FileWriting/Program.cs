
namespace _03_1_genericStack_Indexer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region generic stack
            GenericStack<int> stack = new GenericStack<int>(5);
            stack.Push(5);
            stack.Push(4);
            stack.Push(2);
            stack.Push(3);
            stack.Push(1);

            Console.WriteLine(stack[0]); // 5
            Console.WriteLine(stack.GetItemAtIndex(4)); // 1
            Console.WriteLine(stack.IsFull()); // True
            Console.WriteLine(stack.Pop()); // 1
            Console.WriteLine(stack.Peek()); // 3
            Console.WriteLine(stack.IsEmpty()); // False
            Console.WriteLine(stack.RemoveByValue(2)); // True
            #endregion




            #region changing Add behavior, Writing to a file
            Console.WriteLine(Directory.GetCurrentDirectory());

            FileWriting<string> fileWriting = new FileWriting<string>("log.txt");
            fileWriting.Add("Hello  s");

            Console.WriteLine(fileWriting.RealAllLines());
            #endregion
        }
    }
}
