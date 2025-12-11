namespace _08_Threading
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Threading: performing multiple tasks running together, each task (represents an entire app) runs parallel in a separate processor
            //Console.WriteLine(Environment.ProcessorCount); // 8
            Thread.CurrentThread.Name = "New Name for the thread";

            #region single thread
            //Console.WriteLine("---------- Single thread ----------");

            //Console.WriteLine($"Before function call, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
            //Method1();
            //Method2(); // will not be executed until Method1 is done
            //Console.WriteLine($"After function call, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}"); // will not be executed until Method2 is done
            #endregion



            #region mutli thread
            //Console.WriteLine("---------- Multi threading ----------");

            //Console.WriteLine($"Before functions call");
            //Thread th1 = new Thread(Method1); // Foreground Thread (default) : run until finish even if parent thread is done
            ////Thread th1 = new Thread(() => Method1()); // using lambda expression
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




            #region Thread Pool: pre-defined threads >>> Background Threads (problem) (the functions may not execute entirely)
            //Console.WriteLine("--------");
            //ThreadPool.QueueUserWorkItem(obj => Method1());
            //ThreadPool.QueueUserWorkItem(obj => Method2());
            #endregion




            #region tpl: task pool library: uses thread pool internally (background thread (problem))
            //Task t1 = new Task(() => Method3(10));
            //Task t2 = Task.Run(Method2);
            //Task t3 = Task.Factory.StartNew(Method2);
            Task<int> t4 = Task.Factory.StartNew(Method4); // "int" return
            //t1.Start();
            // //t1.Wait(); // blocking main thread until t1 complete
            Console.WriteLine("Main continue");
            //Console.WriteLine(t4.Result); // blocking main thread until t4 complete

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            t4.ContinueWith((prevTask) => // when t4 is done (don't block main), execute the following block of code
            {
                if (prevTask.IsFaulted) // if method4 throw exception
                {  
                    Console.WriteLine($"Error: {prevTask.Exception.InnerException}");
                    return;
                }
                Console.WriteLine("Continue");
                Console.WriteLine(prevTask.Result);
                if(prevTask.IsCanceled) { }
            });

            Console.WriteLine("Main End");
            //cancellationTokenSource.Cancel();
            Console.ReadLine();
            #endregion

            //Task.WaitAll(t1, t2, t3) // wait until all tasks are done
        }
        static void Method1()
        {
            Console.WriteLine($"Mehod 1 Start, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}-{Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(1000);
            Console.WriteLine($"Mehod 1 End, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
        }
        static void Method2()
        {
            Console.WriteLine($"Mehod 2 Start, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
            Thread.Sleep(3000);
            Console.WriteLine($"Mehod 2 End, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
        }
        static void Method3(int x)
        {
            Console.WriteLine($"Mehod 3 Start, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}-{Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(1000);
            Console.WriteLine($"Mehod 3 End, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}");
        }
        static int Method4()
        {
            Console.WriteLine($"Mehod 4 Start, {Thread.CurrentThread.ManagedThreadId}-{Thread.CurrentThread.Name}-{Thread.CurrentThread.IsThreadPoolThread}");
            Thread.Sleep(1000);
            //throw new Exception("new error");
            return 20;
        }
        static void Method5(CancellationToken t)
        {
            if (t.IsCancellationRequested) t.ThrowIfCancellationRequested();
        }
    }
}
