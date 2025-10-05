//////////////////////////////////////////////////
/// top level statement
//////////////////////////////////////////////////

// top level statement >>>> if you removed all code and write your code outside the namespace, the compiler will make Main method implicitly
// only one file (in the same project) can use top level statement
// top level statement has higher priority in case you have Main method in another file

global using System.Diagnostics; // "global" so as not to import it in the entire namespace
using System; // done implicitly (double click on the project name) >>>>   <ImplicitUsings>enable</ImplicitUsings>
using ConsoleApp1; // to call the Main method
using static System.Console; // you can use WriteLine directly
using Utility; // to use class A from another project B (right click on project B, add, project reference, choose the class)

WriteLine("Hello from Program"); // i can use WriteLine without the class name >>> using static
ABC.Main();

Stopwatch sw = Stopwatch.StartNew(); // System.Diagnostics.Stopwatch

Complex c1 = new Complex(10, 29);
c1.Real = 100;
c1.Img = 50;

Console.WriteLine($"{c1.Img}, {c1.Real}"); // 50, 100
Console.WriteLine(c1); // 100 + 50j


//////////////////////////////////////////////////
// Object initializer, Property
//////////////////////////////////////////////////
Complex c2 = new Complex(11, 28) { Real = 40, Img = 50 };
Complex c3 = new Complex() { Real = 3, Img = 4 };
Console.WriteLine(c2); // 40 + 50j
Console.WriteLine(c3); // 3 + 4j

Emp e1 = new Emp();
e1.Id = 1;
e1.Name = "Abdallah";
Console.WriteLine($"{e1.Id}, {e1.Name}"); // 1, Abdallah


//////////////////////////////////////////////////
// "as", "is"
// casting between parent and child (safely) using "as", "is" >>> with ref type not value type
//////////////////////////////////////////////////

object o1 = new Complex() { Real = 9, Img = 8 };
//o1 = "Aly"; 
//Complex c4 = (Complex) o1; // unsafe cause "o1" can be a string or anything cause it's aboject

// "as"
Complex c4 = o1 as Complex; // if it can be casted to Complex, cast it, else return null
Console.WriteLine(c4?.Real); // 9

if(c4 != null )
    Console.WriteLine(c4.Real); // 9
else
    Console.WriteLine(c4);


// "is"
if(o1 is Complex)
{
    Complex c5 = (Complex)o1;
    Console.WriteLine(c5.Real); // 9
}
// shorthand for "is"
if (o1 is Complex c)
{
    Console.WriteLine(c.Real); // 9
}