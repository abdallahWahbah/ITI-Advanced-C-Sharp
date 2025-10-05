namespace _02_2_generics
{
    internal class Program
    {
        static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;

            // i can't assign 0 or null cause i don't guarantee that all types (like class) can assign 0  
            // what i can do with "T" // not in the function logic
            // 1- GetHashCode()
            // 2- ToString()
            // 3- Equals()
            // 4- GetType()
            // 5- define variable of type T
            T z;
            // 6- equal operator
            z = x;
            // 7- default >>>
            z = default; // if T is int it will assign 0, is string assign empty
            // 8- assign it to object >>> (boxing)
            object o = z;
            // 9- assign object to it >>> (unboxing)
            z = (T)o;
        }
        // adding constraints, the object calling the function must implement IComparable interface
        static void Swap222<T>(ref T x, ref T y) where T : IComparable
        {
            x.CompareTo(y);
            //T z = default;
            //z.CompareTo(x);
        }
        // the object calling the function must be class (primary constraint) and must implement IComparable interface (secondary constraint)
        static void Swap333<T>(ref T x, ref T y) where T : class, IComparable
        {

        }
        static void Swap444<T1, T2, T3>(T1 x, T2 y, T3 z)
        {

        }
        static void Main(string[] args)
        {
            StackUserDefined<int> stack1 = new StackUserDefined<int>();
            StackUserDefined<string> stack2 = new StackUserDefined<string>();
            StackUserDefined<Complex> stack3 = new StackUserDefined<Complex>();
            Complex c1 = new Complex() { Real = 10, Img = 20 };
            Complex c2 = new Complex() { Real = 30, Img = 40 };


            stack1.Push(1);
            stack1.Push(2);
            stack1.Push(3);
            stack2.Push("Abdallah");
            stack2.Push("Mahmoud");
            stack2.Push("Wahbah");
            stack3.Push(new Complex() { Real = 50, Img = 60 });

            Console.WriteLine(stack1.Pop()); // 3
            Console.WriteLine(stack2.Pop()); // wahbah

            // user defined generic function
            float f1 = 1.1f, f2 = 2.2f;
            int x1 = 1, x2 = 2;
            string s1 = "Abdallah", s2 = "Wahbah";

            Swap<float>(ref f1, ref f2);
            Swap<int>(ref x1, ref x2);
            Swap<string>(ref s1, ref s2);
            Swap<Complex>(ref c1, ref c2);
            Swap222(ref c1, ref c2);
            Swap444(1, 2.2, "String value"); // the function does nothing

            Console.WriteLine($"{x1}, {x2}"); // 2, 1
            Console.WriteLine($"{f1}, {f2}"); // 2.2, 1.1
            Console.WriteLine($"{s1}, {s2}"); // Wahbah, Abdallah
            Console.WriteLine(c1); // 30 + 40j
            Console.WriteLine(c2); // 10 + 20j
        }
    }
}
