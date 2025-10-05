using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility
{
    public class Emp
    {
        int id;
        string name;
        string address;
        string school;

        public int Id { get => id; set => id = value; }
        public string Name
        {
            get => name;
            set
            {
                if (value.Length >= 3)
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }
        // private set or get
        public string Address { private get => address; set => address = value; } // you can read it only inside the class
        public string School { get => school; } // readonly

    }
}
