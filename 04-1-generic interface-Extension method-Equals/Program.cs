using System;

namespace _04_1_generic_interface_Extension_method_Equals
{
    internal class Program
    {
        static bool Fun1(int r)
        {
            return r % 4 == 0;
        }
        static void Main(string[] args)
        {
            // generic interface
            ABC abc = new ABC();
            IOperation<int> operation1 = abc;
            IOperation<string> operation2 = abc;
            Console.WriteLine(operation1.Add(1, 2)); // 3
            Console.WriteLine(operation2.Add("Ahmed ", "Aly")); // Hello: Ahmed Aly



            // static class with static method, uses Predicate as callback
            List<int> l1 = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14];
            var evenNumbers = ListExtension.MyFindAll(l1, x => x % 2 == 0); // 2, 4, 6, 8, 10, 12, 14
            var oddNumbers = ListExtension.MyFindAll(l1, x => x % 2 != 0); // 1, 3, 5, 7, 9, 11, 13
            var res1 = ListExtension.MyFindAll(l1, Fun1); // 4, 8, 12
            var res2 = ListExtension.MyFindAll(l1, x => x % 5 == 0); // 5, 10



            // Extension method
            ListExtension.Print(1999); // 2222222222222222
            int num1 = 1999;
            num1.Print(); // 2222222222222222 // the same as ListExtension.Print(1999);
            var res3 = l1.MyFindAll(x => x % 6 == 0); // 6, 12
            foreach (var i in res3) Console.Write($"{i}, ");



            // Target
            Employee e1 = new Employee() { Id = 1, Name = "Ali", Age = 30 };
            Employee e2 = new Employee() { Id = 12, Name = "Sara", Age = 30 };
            Employee e3 = new Employee() { Id = 12, Name = "Sara", Age = 30 };
            Action action = e1.Print; // if you debug, the target for action is e1
            action += e2.Print;
            action.Invoke(); // print e1, e2



            // Equals, ReferenceEquals
            // without override Equals in Emp class
            // if Emp is a class >>> Equals() will return false (cause it compares references)
            // if it's a struct >>> return true (when they equal) (cause it compares the state(values))
            if (e2.Equals(e3)) Console.WriteLine("E2 equlas E3");
            else Console.WriteLine("E2 doesn't equla E3");

            // object.Equals(e2, e3); the same as  >>>  e2.Equals(e3) 

            Console.WriteLine(object.ReferenceEquals(e2, e3)); // False >>> they don't point at the same object (ref) in memory
            e2 = e3;
            Console.WriteLine(object.ReferenceEquals(e2, e3)); // True
        }
    }
}
