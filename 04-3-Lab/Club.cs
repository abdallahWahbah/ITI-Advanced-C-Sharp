using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_3_Lab
{
    internal class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<Employee> employees = new List<Employee>();

        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
            emp.employeeFire += RemoveEmployee;
        }
        public void RemoveEmployee(Employee emp)
        {
            employees.Remove(emp);
        }
        public void AffectTheClub(Department dept)
        {
            dept.clubFire += AddEmployee;
        }
        public override string ToString()
        {
            foreach (var emp in employees) { Console.WriteLine(emp.Name); }
            return base.ToString();
        }
    }
}
