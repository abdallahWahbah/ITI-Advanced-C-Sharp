namespace _06_1_try_catch_checked
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// better to protect your code before exception happens
            //int firstNum;
            //bool canParse;
            //do
            //{
            //    Console.WriteLine("Please enter a valid number");
            //    canParse = int.TryParse(Console.ReadLine(), out firstNum);
            //} while (canParse == false);


            try
            {
                int x = int.Parse(Console.ReadLine()); // another method >> Convert.ToInt32(Console.ReadLine())
                int y = int.Parse(Console.ReadLine());
                int z = x / y;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("You must enter number");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You can't divide by zero");
                // throw; // so that if this try-catch in a method, you give a feedback in the line calling this method (catch the "throw" using try-catch)
                //throw new Exception("You can't divide by zerooooooo"); // handle this in case this "try-catch" is in a method that is being called
                //throw new Exception("HHHHHHHHHHHHHH", ex); // new exception message, old exception // when handling >> catch(Exception ex){cw(ex.Message, ex.InnerException)}
            }
            //catch // the same as >>> catch (Exception ex)  
            catch (Exception ex)  // general exception in case you will not handle all exceptions like NullReferenceException, IndexOutOfRangeException.....
            {
                Console.WriteLine($"run time Exception error: {ex.Message}");
            }
            finally // will be executed in all cases, if there is exception or if there is no exception
            {
                // you can use try/finally without using catch but it will stop the application (crash) in case of Exception
                Console.WriteLine("Finally");
            }
            // you can use try-finally without catch
            // we use finally (mostly) in closing connections with DB (will be executed if there is an exception)


            //////////////////// checked block >>> when overflow >> throw exception
            checked
            {
                int a1 = 4524;
                byte a2 = (byte)a1; // >>>>> better using Convert.ToByte(a1) cause it throws automatically

            }
            // any arithmatic operation for types less than int like "byte", "short" >>> the result is int 
            byte a3 = 3, a4 = 4, a5;
            //a5 = a3 + a4; // compile error
            a5 = (byte)(a3 + a4);
        }
    }
}
