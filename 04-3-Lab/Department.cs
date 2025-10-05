using _04_3_Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_3_Lab
{
    internal class Department
    {
        public event Action<Employee> clubFire;
        public int DeptId {  get; set; }
        public string DepartName { get; set; }

        private List<Employee> employees = new List<Employee>();
        
        public void AddEmployee(Employee emp)
        {
            employees.Add(emp);
            emp.employeeFire += RemoveEmployee;

            clubFire?.Invoke(emp); // when adding employee to a department, add it automatically to the club
        }
        public void RemoveEmployee(Employee emp)
        {
            employees.Remove(emp);
        }
        public override string ToString()
        {
            return $"dept id: {DeptId} --- dept name: {DepartName}  --- Number of employees: {employees.Count}";
        }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false ;
            if(obj.GetType() != GetType()) return false ;
            Department dept = (Department) obj ;
            return dept.DeptId == DeptId && dept.DepartName == DepartName;
        }
    }
}
