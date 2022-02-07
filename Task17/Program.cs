using Task17.Data;
using Task17.Models;

namespace Task17
{
    public class Program
    {
        private static void Main(string[] args)
        {
            DbInitializer.Run();
        
            // var instance = Activator.CreateInstance(typeof(Tasks));
            // var methods = typeof(Tasks).GetMethods();
            //
            // foreach (var method in methods)
            // {
            //     if (method.Name.Contains("Task"))
            //         method.Invoke(instance, null);
            // }
            //
            // Console.ReadKey();
            
            Task19();
        }

        //
        public static void Task19()
        {
            var names = new List<string>()
            {
                "Дмитрий", "Альберт"
            };

            var session = DbManager.OpenSession();
            
            //Contains
            var workers = session.Query<Worker>()
                .Where(w => w.Company.Name == "Intel")
                .Where(w =>
                    session.Query<Worker>()
                        .Where(w => names.Contains(w.Name))
                        .Select(w => w.Name)
                        .Contains(w.Name))
                .ToList();

            foreach (var worker in workers)
            {
                Console.WriteLine($"{worker.Id} - {worker.Name}");
            }
            
            //Any
            var workers2 = session.Query<Worker>()
                .Where(w => w.Company.Name == "Intel")
                .Where(w =>
                    session.Query<Worker>()
                        .Where(w => names.Any())
                        .Select(w => w.Name)
                        .Contains(w.Name))
                .ToList();

            foreach (var worker in workers2)
            {
                Console.WriteLine($"{worker.Id} - {worker.Name}");
            }
            
        }
    }
}

