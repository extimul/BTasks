using Task17.Data;

namespace Task17
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DbInitializer.Run();
        
            var instance = Activator.CreateInstance(typeof(Tasks));
            var methods = typeof(Tasks).GetMethods();
        
            foreach (var method in methods)
            {
                if (method.Name.Contains("Task"))
                    method.Invoke(instance, null);
            }

            Console.ReadKey();
        }
    }
}

