using System.Threading.Tasks;

namespace _08_Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Threading: performing multiple tasks running together, each task (represents an entire app) runs parallel in a separate processor
            //Console.WriteLine(Environment.ProcessorCount); // 8
            //Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            //Console.WriteLine(Thread.CurrentThread.Name);

            #region single thread
            //Console.WriteLine("---------- Single thread ----------");

            //Console.WriteLine($"Before function call, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
            //Method1();
            //Method2(); // will not be executed until Method1 is done
            //Console.WriteLine($"After function call, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}"); // will not be executed until Method2 is done
            #endregion




            #region mutli thread:: (start, join, Sleep), lambda expression, Foreground, Background
            //Console.WriteLine("---------- Multi threading ----------");
            //// // 2 types of threads: Foreground, Background
            //// // Foreground Thread (default): continue execution even if the parent thread finished execution >>>>> if the parent (ex: Main thread) finished execution but it has an enternal thread (ex: Method1) that loops 1000 times >>> continue executing Method1
            //// // Background Thread: stop executing Method1 if the parent thread finished execution  
            //Thread.Sleep(1000);

            //Console.WriteLine($"Before functions call");
            //Thread th1 = new Thread(Method1);
            ////Thread th1 = new Thread(() => Method1()); // using lambda expression (to enable you send data to the function)
            //Thread th2 = new Thread(Method2) { Name = "Thread 2" };
            ////Thread th2 = new Thread(Method1) { Name = "Thread 2", IsBackground = true }; // "IsBackground = true": if the parent thread is done, don't wait for this thread to end >> finish it immediatly 
            //th1.Start(); // will start with th2
            //th2.Start();
            //Console.WriteLine($"Before functions call also"); // executed before threads also (not necessary cause we have 3 threads now >>> "Before", "Method 1 start", "Method 2 start")
            //th1.Join(); // don't execute anything after this line unless th1 is done execution
            //Console.WriteLine("After th1 is done");
            //th2.Join(); // don't execute anything after this line unless th2 is done execution
            //Console.WriteLine("After th2 is done");
            #endregion




            #region Threading problems
            // 1- race conditions: (multiple threads chaning the same variable)
            // if you run 2 threads referring to the same function, you may have unexpected results 
            // to avoid this, you can """lock""" the part that you except it may harm the app  (making dead lock)
            #endregion




            #region Task, Thread Pool: pre-defined Background Threads

            // // const of making threads is high, slow and consumes more memory
            // // Thread Pool is a collection of threads ::: when making new thread, take it from the thread pool >>> don't wait for the crl to make new Thread
            // // and if number of threads exceeds the thread pool, clr with take some places from memory to make threads
            // // all threads made by thread pool are background threads (finished if parent is finished execution)
            // // background threads >> (problem) (the functions (Background: can't change to Foreground) may not execute entirely)
            // // Thread Pool always uses Task not Thread 

            // // Task doesn't create a new Thread, it uses one from the Thread Pool, so it's better for performance than Thread


            Task task1 = Task.Run(() => PrintY(10));
            Task<int> task2 = Task<int>.Run(() =>CountEven(100));
            task2.Wait(); // the same as Join() >>> don't execute anything after this line until task is done (not preferred)
            int evenCount = task2.Result;
            Console.WriteLine(evenCount);
            #endregion




            #region async-await
            RunThreadAsync();
            #endregion

        }
        static void Method1()
        {
            Console.WriteLine($"Mehod 1 Start");
            Thread.Sleep(1000);
            Console.WriteLine($"Mehod 1 End");
        }
        static void Method2()
        {
            Console.WriteLine($"Mehod 2 Start");
            Thread.Sleep(3000);
            Console.WriteLine($"Mehod 2 End");
        }
        static void Method3(int x)
        {
            Console.WriteLine($"Mehod 3 Start");
            Thread.Sleep(1000);
            Console.WriteLine($"Mehod 3 End");
        }
        static int Method4()
        {
            Console.WriteLine($"Mehod 4 Start");
            Thread.Sleep(1000);
            //throw new Exception("new error");
            return 20;
        }
        static void Method5(CancellationToken t)
        {
            if (t.IsCancellationRequested) t.ThrowIfCancellationRequested();
        }
        static void PrintY(int maxNumber)
        {
            for (int i = 0; i < maxNumber; i++)
            {                
                Console.Write("Y");
            }
        }
        static int CountEven(int maxNumber)
        {
            Console.WriteLine();
            int count = 0; 
            for(int i = 0; i < maxNumber; i++)
            {
                if(i % 2 == 0)
                    count++;
            }
            return count;
        }
        // async-await
        static async void RunThreadAsync()
        {
            //Task<int> task = Task<int>.Run(() => CountEven(100));
            //task.GetAwaiter().OnCompleted(() =>
            //{
            //    Console.WriteLine($"------------: {task.Result}");
            //});

            // the same using async-await
            int count = await Task<int>.Run(() => CountEven(100));
            Console.WriteLine($"------------: {count}");
        }
    }
}
