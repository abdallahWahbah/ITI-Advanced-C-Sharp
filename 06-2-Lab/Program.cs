using System.Collections;

namespace _06_2_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exceptions-IDisposable, FileWriter
            using (GenericStack<int> stack = new GenericStack<int>(5))
            {
                stack.Push(5);
                stack.Push(4);
                stack.Push(2);
                stack.Push(3);
                stack.Push(1);
                try
                {
                    stack.Pop();
                    stack.Pop();
                    stack.Pop();
                    stack.Pop();
                    stack.Pop();
                    //stack.Pop();
                    //stack.GetItemAtIndex(13);
                    //stack.Peek();
                    //Console.WriteLine(stack[9]);
                    stack[10] = 1008;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }; // Dispose is called automatically when using "using"



            // TextWriter, TextReader
            ArrayList arr = new ArrayList();
            string filePath = "output.txt";
            arr.Add("Hello");
            arr.Add("World");
            arr.Add(123);
            arr.Add(45.67);


            using (TextWriter writer = new StreamWriter(filePath))
            {
                foreach (var item in arr)
                {
                    writer.WriteLine(item); // write each item in "arr" in a new line
                }
            }
            Console.WriteLine($"Data written to {Directory.GetCurrentDirectory()}");


            using (TextReader reader = new StreamReader(filePath))
            {
                string? line;
                do
                {
                    line = reader.ReadLine();
                    if (line != null)
                        Console.WriteLine("Read: " + line);
                }
                while (line != null);
            }

        }
    }
}
