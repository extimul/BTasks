namespace Task14;

class Progarm
{
    private static async Task Main()
    {
        // Task4();
        // Task5();
        // Task7();
        // for (int i = 0; i < 10; i++)
        // {
        //     await Task8();
        // }
        // Task9();
        // Task10();
        Task11();
        // Task13();
        Console.ReadLine();
    }

    private static async void Task4()
    {
        await FactorialAsync(4);
        await FactorialAsync(6);
    }

    private static async Task FactorialAsync(int num)
    {
        await Task.Run(() =>
        {
            if (num <= 0)
                throw new Exception($"Параметр не может быть меньше 0");
            
            int res = 1;
            for (int i = 1; i <= num; i++)
            {
                res *= i;
            }
                
            Console.WriteLine($"Факториал равен {res}");
        });
    }

    private static async void Task5()
    {
        await WriteAsync();

        Console.WriteLine("Main");
        
        await ReadAsync();
    }

    private static async Task WriteAsync()
    {
        await using var writer = new StreamWriter("test.txt");
        {
            for (var symbol = 'A'; symbol <= 'Z'; symbol++)
            {
                await writer.WriteAsync(symbol);
            }
        }
    }

    private static async Task ReadAsync()
    {
        using var reader = new StreamReader("test.txt");
        string result = await reader.ReadToEndAsync();
        Console.WriteLine(result);
    }

    private static async void Task7()
    {
        await FactorialTaskAsync(3);

        int r = await FactorialTaskTAsync(5);
        Console.WriteLine(r);

        int a = await FactorialValueTaskAsync(6);
        Console.WriteLine(r);
    }

    private static async Task FactorialTaskAsync(int n)
    {
        Task.Run(() =>
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }
                
            Console.WriteLine($"Факториал равен {res}");
        });
    }

    private static async Task<int> FactorialTaskTAsync(int n)
    {
        return await Task.Run(() =>
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }

            return res;
        });
    }

    private static async ValueTask<int> FactorialValueTaskAsync(int n)
    {
        return await Task.Run(() =>
        {
            int res = 1;
            for (int i = 1; i <= n; i++)
            {
                res *= i;
            }

            return res;
        });
    }

    private static async Task Task8()
    {
        await FactorialAsync(3);
        await FactorialAsync(4);
        await FactorialAsync(5);
    }

    private static void Task9()
    {
        RunParallel();
    }

    private static async void RunParallel()
    {
        await Task.WhenAll(FactorialTaskAsync(3), FactorialTaskAsync(4), FactorialTaskAsync(5));
    }

    private static async void Task10()
    {
        try
        {
            //без await не работает
            await FactorialAsync(-4);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static async void Task11()
    {
        var tasks = Task.WhenAll(FactorialAsync(-3), FactorialAsync(-4), FactorialAsync(-5));
        try
        {
            await tasks;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception: {e.Message}");
            foreach (var innException in tasks.Exception.InnerExceptions)
            {
                Console.WriteLine($"Inner Exception: {innException.Message}");
            }
        }
    }

    private static void Task13()
    {
        var tokenSource = new CancellationTokenSource();
        var token = tokenSource.Token;
        MethodAsync(token);
        Thread.Sleep(3000);
        tokenSource.Cancel();
    }

    private static async void MethodAsync(CancellationToken cancellationToken)
    {
        await Task.Run(() => DoWork(cancellationToken), cancellationToken);
    }

    private static void DoWork(CancellationToken cancellationToken)
    {
        for (int i = 0; i < 10; i++)
        {
            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine("Операция прервана");
                return;
            }
            Console.WriteLine($"Квадрат числа: {i * i}");
            Thread.Sleep(1000);
        }
    }

}