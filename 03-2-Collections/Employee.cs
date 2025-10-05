using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_2_Collections
{
    internal class Employee: IComparable<Employee> // I used IComparable interface to sort the objects in the list of objects by int (salary)
    {
        public int EmployeeNo { get; set; }
        public string FullName { get; set; }
        public decimal StartSalary { get; set; }

        public Employee() { }
        public Employee(int _EmplyeeNo, string _FullName, decimal _StartSalary)
        {
            this.EmployeeNo = _EmplyeeNo;
            FullName = _FullName;
            StartSalary = _StartSalary;
        }
        public static void PromoteEmployee(Employee emp)
        {
            Console.WriteLine($"Promoting Emplyee: {emp.FullName}");
        }
        public int CompareTo(Employee emp) // IComparable interface method
        {
            // sorting based on salary
            if (this.StartSalary > emp.StartSalary) return 1;
            else if (this.StartSalary < emp.StartSalary) return -1;
            else return 0; 
        }
    }
    class SortByName: IComparer<Employee> // another interface for sorting (the same as IComparable)
    {
        public int Compare(Employee emp1, Employee emp2)
        {
            return emp1.FullName.CompareTo(emp2.FullName);
        }
    }
}
