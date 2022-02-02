namespace Task11;

class Program
{
    private static int x = 0;

    private static object locker = new object();
    
    private static void Main()
    {
        // for (int i = 0; i < 1000; i++)
        // {
        //     var t1 = new Thread(new ThreadStart(delegate
        //     {
        //         int id = i;
        //         Console.WriteLine("Thread: №" + id);
        //         Thread.Sleep(5000);
        //         Console.WriteLine($"Thread({id}) is awake");
        //     }));
        //     t1.Name = "Thread" + i;
        //     t1.Start();
        //     
        //     DisplayThreadInfo(t1);
        // }
        //
        // Console.ReadKey();

        // var currentThread = Thread.CurrentThread;

        // Task3();
        // Task4();
        // Task7();
        // Task10();
        // Task11();
        
        var task13 = new Task13(new int[10,10]);
        task13.Run();
    }

    public static void Task3()
    {
        var t1 = new Thread(new ThreadStart(delegate
        {
            Console.WriteLine("Thread");
        }));

        t1.Name = "My thread";
        
        Console.WriteLine("До запуска");
        DisplayThreadInfo(t1);
        
        t1.Start();
        Console.WriteLine("После запуска");
        
        // Thread.Sleep(5000);
        
        DisplayThreadInfo(t1);
    }

    private static void Task5()
    {
        var t1 = new Thread(new ThreadStart(delegate
        {
            Console.WriteLine("Thread");
        }));

        t1.Priority = ThreadPriority.Highest;
        
        DisplayThreadInfo(t1);
        t1.Start();
        DisplayThreadInfo(t1);
    }

    #region ThreadStart

    private static void Task7()
    {
        var secondThread = new Thread(Count);
        secondThread.Start();

        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine($"Главный поток: {i * i}");
            Thread.Sleep(300);
        }
    }

    
    private static void Count()
    {
        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine($"Второй поток: {i * i}");
            Thread.Sleep(400);
        }
    }

    #endregion

    #region ParamThreadStart

    private static void Task10()
    {
        var t = new Thread(() => Count2(9));
        
        var thread = new Thread(Count2);
        thread.Start(9);

        for (int i = 0; i < 9; i++)
        {
            Console.WriteLine($"Главный поток: {i * i}");
            Thread.Sleep(300);
        }
    }

    private static void Count2(object number)
    {
        int n = (int) number;
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Второй поток: {i * i}");
            Thread.Sleep(400);
        }
    }

    #endregion

    #region Sync

    private static void Task11()
    {
        for (int i = 0; i < 5; i++)
        {
            var myThread = new Thread(Count3);
            var myThread2 = new Thread(Count3);
            myThread.Name = "Поток " + i.ToString();
            myThread.Start();
            myThread2.Start();
        }
 
        Console.ReadLine();
    }
    
    private static void Count3()
    {
        lock (locker)
        {
            x = 1;
            for (int i = 1; i < 9; i++)
            {
                Console.WriteLine("{0}: {1}", Thread.CurrentThread.Name, x);
                x++;
                Thread.Sleep(100);
            }
        }
    }


    #endregion
    
    public static void DisplayThreadInfo(Thread thread)
    {
        try
        {
            Console.WriteLine($"Имя потока: {thread.Name}");
            Console.WriteLine($"Запущен ли поток: {thread.IsAlive}");
            Console.WriteLine($"Приоритет потока: {thread.Priority}");
            Console.WriteLine($"Статус потока: {thread.ThreadState}");
            Console.WriteLine($"Домен приложения: {Thread.GetDomain().FriendlyName}");
        }
        catch (ThreadStateException)
        {
            Console.WriteLine("Thread is dead");
        }
        
    }
}

