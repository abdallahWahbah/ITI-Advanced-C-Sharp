using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_1_generic_interface_Extension_method_Equals
{
    internal class Employee
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        public void Print()
        {
            Console.WriteLine(this);
            //Console.WriteLine(ToString()); // the same
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
