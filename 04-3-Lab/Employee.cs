using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_3_Lab
{
    internal class Employee
    {
        public event Action<Employee> employeeFire;
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
        int abscentDays = 0;

        public int GetAbsentDays() => abscentDays;
        public void IncreaseAbscentDays()
        {
            abscentDays++;
            if (abscentDays > 3)
                employeeFire.Invoke(this);
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"{Id}: {Name} : {Age}";
        }
        public override bool Equals(object? obj)
        {
            if(obj == null ) return false;
            if(obj.GetType() != GetType()) return false;
            Employee emp = (Employee)obj;
            return emp.Id == Id && emp.Name == Name && emp.Age == Age;
        }
    }
}
