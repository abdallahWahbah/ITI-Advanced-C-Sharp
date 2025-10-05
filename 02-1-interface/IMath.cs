using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_1_interface
{
    ////////////////////////////////////////
    // multiple implementations, default implementation, explicit implementation
    ////////////////////////////////////////
    interface IH
    {
        int Divide(int x, int y);
    }
    interface ID
    {
        int Divide(int x, int y);
    }
    internal interface IMath : IH, ID  // an interface can implement another interface
    { // any class implementing "IMath" must implement "Divide" function in "IH" interface cause "IMath" implements "IH" , the same for "ID"
        int Add(int x, int y);
        int Subtract(int x, int y);
        int X { get; set; } // any class implementing this interface must implement "X" property

        // default implementation (C# 9) (optional: leave or implement) for classes who don't want to implement some methods
        int Multiply(int x, int y)
        {
            return x * y;
        }
    }
    class XYZ : IMath
    {
        public int X { get; set; }
        public int Add(int x, int y)
        {
            return x + y;
        }
        public int Subtract(int x, int y)
        {
            return x - y;
        }
        int IH.Divide(int x, int y) // explicit implementation: in case the 2 interfaces have the same function name
        {
            // mandatory cause "IMath" implements "IH" which has Divide abstract function
            return x / y;
        }
        int ID.Divide(int x, int y)
        {
            // mandatory cause "IMath" implements "ID" which has Divide abstract function
            return 525120631;
        }
        // of course you can make "IMath" implements nothing, now class XYZ implements IMath, ID, IH
    }
}
