using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_1_interface
{
    /// <summary>
    /// ///////////////////////////////////
    /// </summary>
    /// 
    ///////////////////////////////////
    /// IComparable, IComparer<Employee>, ICloneable
    ///////////////////////////////////
    internal class Employee: IComparable, IComparer<Employee>, ICloneable
    {
        public int ID {  get; set; }
        public string Name { get; set; }
        // to Sort any user defined type, it must implement "IComparable" interface which has method "CompareTo"
        public int CompareTo(object obj)
        {
            Employee emp = obj as Employee;
            if (emp == null) return 1;

            // // Compare By ID
            //if (emp.ID > ID) return 1;
            //else if (emp.ID < ID) return -1;
            //else return 0;

            // compare by name then by id
            int nameComparison = Name.CompareTo(emp.Name);  // Compare by Name first
            if (nameComparison != 0) return nameComparison;
            else return ID.CompareTo(emp.ID); // If names are equal, compare by ID
        }

        public int Compare(Employee emp1, Employee emp2) // IComparer is the same as IComparable except that when using Array.sort() >> you pass the Comparer class as a second param
        {
            if (emp1 == null || emp2 == null) return 0;

            if (emp1.ID == emp2.ID) return emp1.Name.CompareTo(emp2.Name);
            else return emp1.ID.CompareTo(emp2.ID);  // if names are equal, compare by id
        }
        public object Clone() // to be able to make a clone when using equal with ref types >>> new different places and objects 
        {
            return new Employee() { Name = Name, ID = ID };
        }

    }
}
