namespace delegates
{
    // Delegate (pointer to a function) is a variable holding address to a function in memory
    public delegate int Delegate_return_int_input_2_int(int num1, int num2); // this delegate must point to a function returning int and accepting 2 int
    public delegate float Delegate_return_float_input_2_float(float num1, float num2);
    public delegate void Delegate_return_void_input_nothing();
    public delegate bool DelegateBoolean(int x, int y);
    public delegate T GenericDelegate<A, B, T>(A x, B y); // delegate takes 2 inputs of type "A", "b" >> return of type "T" (last param is return type)
    public delegate T GenericDelegate2<A, B, C, T>(A x, B y, C z);
    public delegate bool Delegate_return_boolean_input_int(int x);

    internal class Program
    {
        static int Add(int x, int y) => x + y;
        static int Multiply(int x, int y) => x * y;
        static void Print1() => Console.WriteLine("1111111111111111");
        static void Print2() => Console.WriteLine("2222222222222222");
        static void FunctionReceivingCallback(Delegate_return_int_input_2_int del1, Delegate_return_void_input_nothing del2)
        {
            int num1 = 10, num2 = 9;
            Console.WriteLine(del1(num1, num2));
            del2();
        }
        static void Main(string[] args)
        {
            Delegate_return_int_input_2_int del1 = Add;
            Delegate_return_void_input_nothing del2 = Print1;
            Console.WriteLine(del1.Invoke(14, 3)); // 17
            del1 = Multiply;
            // shorter way for invoking
            Console.WriteLine(del1(5, 3)); // 15
            del2(); // 1111111111111111
            del2 = Print2;
            del2(); // 2222222222222222



            //////////////////////////////////////////////////
            /// multi cast delegate (executing multiple functions)
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- multi cast delegate (executing multiple functions) ---------------");
            del2 = Print1;
            del2 += Print2;
            del2(); // 1111111111111111, 2222222222222222
            Console.WriteLine(del2.GetInvocationList().Length); // 2



            //////////////////////////////////////////////////
            /// passing delegate as callback
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- passing delegate as callback ---------------");
            del1 = Add;
            del2 = Print1;
            FunctionReceivingCallback(del1, del2); // 19, 1111111111111111



            //////////////////////////////////////////////////
            /// example
            //////////////////////////////////////////////////
            int[] numbers = [5, 6, 1, 3, 2, 5];
            DelegateBoolean delegateBooleanSorting = IsAscending;
            Sorting.SortInt(numbers, delegateBooleanSorting); //  1, 2, 3, 5, 5, 6
            // Sorting.SortInt(numbers, (x, y) => x > y); // using lambda expression (explained below)

            delegateBooleanSorting = IsDescending;
            Sorting.SortInt(numbers, delegateBooleanSorting); // 6, 5, 5, 3, 2, 1



            //////////////////////////////////////////////////
            /// delegate using anonymous function
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- delegate using anonymous function ---------------");
            DelegateBoolean del4 = delegate (int x, int y)
            {
                Console.WriteLine("Boolean Delegate Calling");
                return (x + y) * 12 > 100;
            };
            Console.WriteLine(del4(3, 4));



            //////////////////////////////////////////////////
            /// delegate using lambda expression
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- delegate using lambda expression ---------------");
            Delegate_return_int_input_2_int del5 = (a, b) => (a + b) / 2;
            Console.WriteLine(del5(4, 6));



            //////////////////////////////////////////////////
            /// Generic Delegate
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- Generic Delegate ---------------"); 
            GenericDelegate<int, int, bool> genDel = (a, b) => ((a + b) / 2) == 100;
            GenericDelegate2<float, float, float, string> genDel2 = (a, b, c) => (a + b + c).ToString();
            Console.WriteLine(genDel(50, 150)); // True
            Console.WriteLine(genDel2(1.1f, 2.2f, 3.3f)); // 6.6



            //////////////////////////////////////////////////
            /// FunC, Predicate, Action ::: built-in generic delegates
            /// 
            /// FunC: takes up to 16 input param, the last one is the return type >> can't return bool
            /// Predicate: special type of FunC that return bool, and you don't write  bool in the end <bool>, takes only one param
            /// Action: takes up to 16 input param or zero, return void
            //////////////////////////////////////////////////
            Console.WriteLine("--------------- FunC, Predicate, Action ---------------");

            Func<int, int, int> del6 = (x, y) => x + y;
            Func<int, double, int, double> del7 = (a, b, c) => a + b + c;
            Console.WriteLine(del6(5, 3)); // 8

            Predicate<int> del8 = x => x > 2;
            Console.WriteLine(del8(10)); //True

            Action a1 = () => Console.Write("Hello "); // no params
            a1 += () => Console.WriteLine("from the other side");
            a1(); // Hello from the other side

            Action<int> a2 = x => Console.WriteLine(x); // return is void >>> print the input
            Predicate<int> p2 = x => x > 2; // return is bool >>> print True or false
            a2(5); // 5
            Console.WriteLine(p2(1)); // False



            //////////////////////////////////////////////////
            /// example 1
            //////////////////////////////////////////////////
            List<int> listOfInt = new List<int>() { 10, 20, 30, 31, 43, 59, 60 };
            List<string> names = new List<string>() { "Abdallah", "Mahmoud", "Aly", "Bahaa", "nor" };
            // FindAll receives a Predicate as a callback >> this delegate returns bool and receives the list type<int>
            var numRes = listOfInt.FindAll(IsGreaterThan30); // // 30, 31, 43, 59, 60
            //var numRes = listOfInt.FindAll(x => x >= 30); // // 30, 31, 43, 59, 60
            var namesRes = names.FindAll(longNames); // Abdallah, Mahmoud, Bahaa

            // implementing MyFindAll
            static List<int> MyFindAll(List<int> l3, Delegate_return_boolean_input_int del9){ // you can use Func<int, bool> instead of Delegate_return_....
                List<int> res = new List<int>();
                foreach(var item in l3){
                    if (del9.Invoke(item)) res.Add(item);
                }
                return res;
            }
            var myRes = MyFindAll(listOfInt, x => x >= 20 && x <= 60);
            var myRes2 = MyFindAll(listOfInt, x => x >= 30 && x <= 40);

        }
        static bool IsGreaterThan30(int x)
        {
            return x > 29;
        }
        static bool longNames(string name)
        {
            return name.Length > 3;
            //return name.StartsWith("a"); // return name starting with "a"
        }
        static bool IsAscending(int x, int y)
        {
            return x > y;
        }
        static bool IsDescending(int x, int y)
        {
            return x < y;
        }
    }
}
