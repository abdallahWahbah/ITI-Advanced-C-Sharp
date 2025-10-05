using System.Xml.Linq;

namespace _04_3_Lab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string>() { "Aly", "Bahaa", "Sara", "Abdallah" };
            var res1 = names.MyFindAll(name => name.Length > 3); // Bahaa, Sara, Abdallah
            var res2 = names.MyFindAll(name => name.StartsWith('A')); // Aly, Abdallah
            var res3 = names.MyFindAll(name => name.EndsWith('a')); // Bahaa, Sara
            var res4 = names.MyFindAll(name => name.Contains('l')); // Aly, Abdallah
            foreach (var item in res4) Console.Write($"{item}, ");

            Console.WriteLine("---------------------------------");
            Department dept1 = new Department() { DeptId = 1, DepartName = "Accounting"};
            Club club1 = new Club() { Id = 100, Name = "Sports Club" };

            Employee emp1 = new Employee() { Id = 10, Age = 20, Name = "Aly" };
            Employee emp2 = new Employee() { Id = 11, Age = 21, Name = "Ahmed" };
            Employee emp3 = new Employee() { Id = 12, Age = 22, Name = "Sara" };
            Employee emp4 = new Employee() { Id = 13, Age = 23, Name = "Bahaa" };
            Employee emp5 = new Employee() { Id = 14, Age = 24, Name = "Mohammed" };

            club1.AffectTheClub(dept1);

            Console.WriteLine(dept1); // dept id: 1 --- dept name: Accounting  --- Number of employees: 0
            dept1.AddEmployee(emp1);
            dept1.AddEmployee(emp2);
            dept1.AddEmployee(emp3);
            dept1.AddEmployee(emp4);
            Console.WriteLine(dept1); // dept id: 1 --- dept name: Accounting  --- Number of employees: 4
            emp1.IncreaseAbscentDays();
            emp1.IncreaseAbscentDays();
            emp1.IncreaseAbscentDays();
            emp1.IncreaseAbscentDays();
            Console.WriteLine(dept1); // dept id: 1 --- dept name: Accounting  --- Number of employees: 3

            Console.WriteLine(club1);
        }
    }
    static class ListExtension
    {
        public static List<string> MyFindAll(this List<string> list, Predicate<string> condition)
        {
            var res = new List<string>();
            foreach(var item in list)
            {
                if(condition.Invoke(item)) res.Add(item);
            }
            return res;
        }
    }
}
