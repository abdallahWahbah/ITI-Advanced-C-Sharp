using _04_2_event;
using _16_delegates_;

namespace _04_2_Event_handling
{
    internal class Program
    {
        static bool Cond1(int x, int y) // this function is called "Event handler"
        {
            return x > y;
        }
        static void Main(string[] args)
        {
            Student s1 = new Student() { Id = 1, Name = "Aly" };
            Student s2 = new Student() { Id = 2, Name = "Ahmed" };
            Student s3 = new Student() { Id = 3, Name = "Mohammed" };
            Student s4 = new Student() { Id = 3, Name = "Sara" };
            Student s5 = new Student() { Id = 3, Name = "Aseal" };

            Department d1 = new Department() { DeptId = 100, DepartName = ".Net" };
            Department d2 = new Department() { DeptId = 200, DepartName = "Open Source" };
            d1.AddStudent(s1);
            d1.AddStudent(s2);
            d1.AddStudent(s3);
            Console.WriteLine(d1); // dept id: 100 --- dept name: .Net  ---Number of students: 3
            d2.AddStudent(s4);
            d2.AddStudent(s5);
            Console.WriteLine(d2); // dept id: 200 --- dept name: Open Source  ---Number of students: 2

            s2.IncreaseAbsentDays();
            s2.IncreaseAbsentDays();
            s2.IncreaseAbsentDays();
            s2.IncreaseAbsentDays();
            Console.WriteLine(d1); // dept id: 100 --- dept name: .Net  ---Number of students: 2







            //////////////////////////////////////
            /// another example
            //////////////////////////////////////
            // in this example >>> this class "Program" is called "subscriber"
            // Event Handling
            int[] arr = { 1, 2, 33, 8, 10, 11 };
            Sorting sorting1 = new Sorting();

            sorting1.myDelegate += Cond1; // you can't assign cause "myDelegate" is an event >>> only add another subscribers
            sorting1.SortInt(arr); // 1, 2, 8, 10, 11, 33

            sorting1.myDelegate += (x, y) => x < y;
            sorting1.SortInt(arr); // 33, 11, 10, 8, 2, 1

            sorting1.myDelegate += (x, y) => true;
            sorting1.SortInt(arr); // 1, 2, 33, 8, 10, 11 // only if this the only sorting  (ths same array cause we are returning true always)
        }
    }
}
