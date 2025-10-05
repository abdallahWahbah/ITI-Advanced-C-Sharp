using System.Diagnostics.Metrics;
using System.Reflection;

namespace _02_1_interface
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Engine Series using interface
            SeriesEngine engine = new SeriesEngine();
            OddSeries odd = new OddSeries();
            EvenSeries even = new EvenSeries();
            Fibonicci fibonicci = new Fibonicci();
            engine.PrintNextSeriesNumber(odd);
            engine.PrintNextSeriesNumber(even);
            engine.PrintNextSeriesNumber(odd);
            engine.PrintNextSeriesNumber(even);
            engine.PrintNextSeriesNumber(odd);
            engine.PrintNextSeriesNumber(even);
            Console.WriteLine("-------------------");
            engine.PrintNextSeriesNumber(fibonicci);
            engine.PrintNextSeriesNumber(fibonicci);
            engine.PrintNextSeriesNumber(fibonicci);
            engine.PrintNextSeriesNumber(fibonicci);
            engine.PrintNextSeriesNumber(fibonicci);
            #endregion




            #region IComparable, IComparer, Cloneable

            Console.WriteLine("------------------- Sorting using Array.Sort() built in function -------------------");

            int[] numbers = [100, 6, 5, 3, 1, 2, 99, 20];
            string[] names = ["Zayed", "Abdallah", "Mariam", "Awni"];
            Array.Sort(numbers); // 1, 2, 3, 5, 6, 20, 99, 100
            Array.Sort(names); // Abdallah, Awni, Mariam, Zayed

            Console.WriteLine("------------------- Sorting Pre-defined class -------------------");

            Employee[] employees = new Employee[]
            {
                new Employee() { ID = 10, Name = "Bahaa"},
                new Employee() { ID = 6, Name = "Abdallah"},
                new Employee() { ID = 7, Name = "Zeyad"},
                new Employee() { ID = 4, Name = "Wahbah"},
            };
            // to Sort any user defined type, it must implement "IComparable" interface which has method "CompareTo"
            Array.Sort(employees); // using IComparable
            foreach (var emp in employees) // using IComparer<Employee>
            {
                Console.WriteLine($"ID: {emp.ID}, Name: {emp.Name}");
            }

            Console.WriteLine("------------------- Cloning -------------------");

            Employee emp1 = new Employee() { ID = 1, Name = "Abdallah" };
            Employee emp2 = new Employee() { ID = 2, Name = "Mahmoud" };
            emp2 = (Employee)emp1.Clone();
            Console.WriteLine(emp1.GetHashCode()); // 43942917
            Console.WriteLine(emp2.GetHashCode()); // 59941933
            #endregion




            #region 

            Console.WriteLine("------------------- multiple implementations, default implementation, explicit implementation -------------------");

            IMath m1 = new XYZ();
            Console.WriteLine(m1.Add(1, 2));
            Console.WriteLine(m1.Subtract(1, 2));
            Console.WriteLine(m1.Multiply(10, 20)); // executes the default implementation
            Console.WriteLine(((IH)m1).Divide(10, 2)); // 5
            Console.WriteLine(((ID)m1).Divide(10, 2)); // 525120631
            #endregion
        }
        interface ISeries
        {
            int Current { get; } // any class implementing this interface must implement "Current" property with get only
            //int x; // you can't instantiate instance member
            int GetNextNumber();
            public static int x; // you can instantiate static member

            // most used are functions like "GetNextNumber()" and Property like "Current"
        }
        class SeriesEngine
        {
            public void PrintNextSeriesNumber(ISeries s) // (ISeries s) satisfies O in "SOLID" >> open for extension, closed for modification
            {
                ++ISeries.x; // accessable 
                Console.WriteLine(s.Current);
                Console.WriteLine(s.GetNextNumber());
            }
        }
        class OddSeries : ISeries
        {
            int counter = 1;
            public int Current { get => counter; }
            public int GetNextNumber()
            {
                int temp = counter;
                counter += 2;
                return temp;
            }
        }
        class EvenSeries : ISeries
        {
            int counter = 2;
            public int Current { get => counter; }
            public int GetNextNumber()
            {
                int temp = counter;
                counter += 2;
                return temp;
            }
        }
        class Fibonicci: ISeries
        {
            int current = 1;
            int prevCurrent = 0;
            public int Current { get => current; }

            public int GetNextNumber()
            {
                int temp = current;
                current = current + prevCurrent;
                prevCurrent = temp;
                return temp;
            }
        }
    }
}
