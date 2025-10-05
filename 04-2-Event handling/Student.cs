using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_2_event
{
    // Student class is called "Publisher"
    internal class Student 
    {
        public event Action<Student> studentFire; // step 1
        // "event" keyword forces you to add function to the event not assign  >>> look at AddStudent in Department class
        public int Id { get; set; }
        public string Name { get; set; }
        int absentDays = 0;

        public int GetAbsentDays () => absentDays;
        public void IncreaseAbsentDays ()
        {
            absentDays++;
            if (absentDays > 3)
                studentFire?.Invoke(this);  // step 2
            // "this" referes to the student object
        }

        public override string ToString()
        {
            return $"{Id}-{Name}-{absentDays}";
        }
    }
}
