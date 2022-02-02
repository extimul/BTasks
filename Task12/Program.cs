
namespace Task12
{
    class Program
    {
        private static object locker = new object();

        private static AutoResetEvent waitHandler = new(true);

        private static Mutex _mutex = new Mutex();
        
        private static int x = 0;
        
        static void Main()
        {
            //Task2
            // for (int i = 0; i < 10; i++)
            // {
            //     var t = new Thread(Task2);
            //     t.Start();
            // }
            
            // Task4();
            // Task6();
            // Task8();
            // Task10();
            // var task11 = new ReaderWriterTask();
            var task12 = new ConsumerProducerTask();
        }

        private static void Task2()
        {
            Monitor.Enter(locker);
            
            x = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(x + i);
            }
            
            Monitor.Exit(locker);
            
        //     bool isLocked = false;
        //     try
        //     {
        //         Monitor.TryEnter(locker, ref isLocked);
        //     
        //         x = 1;
        //         for (int i = 0; i < 10; i++)
        //         {
        //             Console.WriteLine(x + i);
        //             Thread.Sleep(100);
        //         }
        //
        //     }
        //     finally
        //     {
        //         if (isLocked) Monitor.Exit(isLocked);
        //     }
        }

        private static void Task4()
        {
            var thread = new Thread(T4Count);
            thread.Start();

            waitHandler.WaitOne();
            
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine($"Главный поток: {x * x}");
            }

            waitHandler.Set();
        }

        private static void T4Count()
        {
            waitHandler.WaitOne();
            x = 0;
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine($"Второй поток: {x * x}");
            }
            
            Thread.Sleep(100);

            waitHandler.Set();
        }

        private static void Task6()
        {
            var thread = new Thread(T6Count);
            thread.Start();

            _mutex.WaitOne();
            
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine($"Главный поток: {x * x}");
            }
        
            _mutex.ReleaseMutex();
        }

        private static void T6Count()
        {
            _mutex.WaitOne();
            x = 0;
            for (int i = 0; i < 10; i++)
            {
                x++;
                Console.WriteLine($"Второй поток: {x * x}");
            }
            
            Thread.Sleep(100);
            
            _mutex.ReleaseMutex();
        }

        private static void Task8()
        {
            for (int i = 1; i < 6; i++)
            {
                SemaphoreReader semaphoreReader = new SemaphoreReader(i);
            }
        }

        private static void Task10()
        {
            TimerCallback timerCallback = DisplayWeather;
            var timer = new Timer(timerCallback, null, 0, 2000);
            
            Console.ReadLine();
        }

        private static void DisplayWeather(object obj)
        {
            Console.WriteLine($"Погода на данный момент {new Random().Next(0,10)}");
        }
    }
}
