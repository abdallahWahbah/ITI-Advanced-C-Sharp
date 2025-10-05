using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_2_event
{
    // this class is called "Subscriber"
    internal class Department
    {
        public int DeptId {  get; set; }
        public string DepartName { get; set; }
        private List<Student> students = new List<Student>();
        
        public void AddStudent(Student std)
        {
            students.Add(std);
            // registration event handler to the delegate
            std.studentFire += RemoveStudent; // step 4
        }
        // "RemoveStudent" ::: event handler >>> must have signature equivelant to the Action<> delegate
        public void RemoveStudent(Student std) // step 3
        {
            students.Remove(std);
        }
        public override string ToString()
        {
            return $"dept id: {DeptId} --- dept name: {DepartName}  ---Number of students: {students.Count}";
        }
    }
}
