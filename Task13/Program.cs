using System.Formats.Asn1;

namespace Task13;

class Program
{
    private static void Main()
    {
        var task = new Task(Task4);
        // Task5();
        // Task7();
        // Task9();
        // Task10();
        // Task11();
        // Task12();
        // Task13();
         // Task14();
        // Task15();
        // Task17();
        Task18();
        
        Console.ReadLine();
    }

    private static void Task4()
    { 
        Task.Run(() => Console.WriteLine("Hello World"));

        Task.Factory.StartNew(() => Console.WriteLine("Hello World"));

        var task2 = new Task(() => Console.WriteLine("Hello World"));
        task2.Start();

        var task3 = new Task(Task4);
        task3.Start();

        task2.Wait();
    }

    private static void Task5()
    {
        var task = Task.Run(() =>
        {
            Console.WriteLine("Начало Task");
            Task.Delay(1000);
            Console.WriteLine("Завершение Task");
        });

        task.Wait();
        
        Console.WriteLine("Заврешение метода Main");
    }

    private static void Task7()
    {
        var outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Запуск внешнего таска");
            var innerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Запуск внутрннего таска");
                Thread.Sleep(1000);
                Console.WriteLine("Конец внутрннего таска");
            });
        });

        outerTask.Wait();
        Console.WriteLine("Окончание Main");

        Console.ReadLine();
    }
    
    private static void Task9()
    {
        var outerTask = Task.Factory.StartNew(() =>
        {
            Console.WriteLine("Запуск внешнего таска");
            var innerTask = Task.Factory.StartNew(() =>
            {
                Console.WriteLine("Запуск внутрннего таска");
                Thread.Sleep(1000);
                Console.WriteLine("Конец внутрннего таска");
            }, TaskCreationOptions.AttachedToParent);
        });

        outerTask.Wait();
        Console.WriteLine("Окончание Main");

        Console.ReadLine();
    }

    private static void Task10()
    {
        Task[] tasks = {
            new(() => Console.WriteLine("Start Task 1")),
            new(() => Console.WriteLine("Start Task 2"))
        };

        foreach (var task in tasks)
            task.Start();
    }

    private static void Task11()
    {
        Task[] tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++)
        {
            var index = i;
            tasks[i] = new Task(() => Console.WriteLine($"Start Task #{index}"));
        }
        
        foreach (var task in tasks)
            task.Start();

        Task.WaitAll(tasks);
        
        Console.WriteLine("Завершение метода");
    }

    private static void Task12()
    {
        var task = Task.Run(() => ReturnWord());
        Console.WriteLine(task.Result);
    }

    private static string ReturnWord()
    {
        return "ABOBA";
    }
    
    private static void Task13()
    {
        Task task1 = new Task(()=>{
            Console.WriteLine($"Id задачи: {Task.CurrentId}");
        });
 
        var task2 = task1.ContinueWith(Display);
 
        task1.Start();
             
        task2.Wait();
        Console.WriteLine("Выполняется работа метода Main");
        Console.ReadLine();
    }
 
    static void Display(Task t)
    {
        Console.WriteLine($"Id задачи: {Task.CurrentId}");
        Console.WriteLine($"Id предыдущей задачи: {t.Id}");
        Thread.Sleep(3000);
    }

    private static void Task14()
    {
        var task = new Task(() => Console.WriteLine("Main method"));
        Console.WriteLine($"Main Task Id: {task.Id}");
        var task2 = task.ContinueWith(Method1);
        var task3 = task2.ContinueWith(Method2);
        task3.Start();
    }

    private static void Method1(Task task)
    {
        Console.WriteLine($"Method 1: TaskID = {Task.CurrentId}");
        Console.WriteLine($"Last Task ID: {task.Id}");
    }

    private static void Method2(Task task)
    {
        Console.WriteLine($"Method 2: TaskID = {Task.CurrentId}");
        Console.WriteLine($"Last Task ID: {task.Id}");
    }

    private static void Task15()
    {
        // Parallel.Invoke(Display, Square);
        // Parallel.For(1, 10, Factorial);
        // var list = new List<int>();
        //
        // for (int i = 0; i < 999999; i++)
        // {
        //     list.Add(i * i);
        // }
        //
        //
        // Parallel.ForEach(list, Display);
    }

    private static void Square()
    {
        for (int i = 0; i <= 100000; i++)
        {
            Console.WriteLine(i * i);
        }
    }

    private static void Factorial(int x)
    {
        int result = 1;
        for (int i = 1; i <= x; i++)
        {
            result *= i;
        }
        Console.WriteLine($"Id текущей задачи: {Task.CurrentId}");
        Console.WriteLine($"Ответ: {result}");
    }

    private static void Display(int x)
    {
        Console.WriteLine(x);
    }

    private static void Task17()
    {
        string path = @"D:\Tasks";
        long totalSize = 0;
        
        if (!Directory.Exists(path)) {
            Console.WriteLine("Директория не существует");
            return;
        }

        string[] files = Directory.GetFiles(path, "*", SearchOption.AllDirectories);
        Parallel.For(0, files.Length,
            index => { var fi = new FileInfo(files[index]);
                long size = fi.Length;
                Interlocked.Add(ref totalSize, size);
            });
        Console.WriteLine("Директория '{0}':", path);
        Console.WriteLine("{0:N0} фалов, {1:N0} байт", files.Length, totalSize);
    }
    
    private static void Task18()
    {
        new MatrixTask().Start();
    }
}
