using NHibernate.Linq;
using Task17.Models;

namespace Task17.Data
{
    public static class DbInitializer
    {
        private static Company Company = new("Intel");

        private static IList<Worker> Workers = new List<Worker>()
        {
            new("Дмитрий", "dmitriy_user", 25000, 44, new DateTime(2010, 1,13)),
            new("Альберт", "albert_user", 32000, 32, new DateTime(2008, 1,29)),
            new("Артем", "user1", 43444, 21, new DateTime(2021, 9,15)),
            new("Алина", "alina", 12345, 23, new DateTime(2015, 11,22)),
            new("Андрей", "user2", 45555, 42, new DateTime(2016, 3,25)),
            new("Виктория", "user3", 1000, 18, new DateTime(2017, 4,1)),
            new("Иван", "ivan", 1000, 21, new DateTime(2021, 11,12)),
            new("Василий", "admin", 100, 86, new DateTime(2023, 11,12)),
            new("Василий", "user4", 12341, 101, new DateTime(2024, 1,22)),
            new("Дмитрий", "user", 500, 23, new DateTime(2016, 4,4)),
        };
    
        public static void Run()
        {
            var session = DbManager.OpenSession();
            using var transaction = session.BeginTransaction();
            
            var data = session.Query<Worker>()
                .ToList();
            
            if (data.Any())
            {
                Console.WriteLine("Данные уже загружены в бд. Окончание процесса.");
                return;
            }
                
            Console.WriteLine("Добавляем данные в бд");
    
            foreach (var worker in Workers)
            {
                Console.WriteLine($"Добавляем рабочего - {worker.Login}");
                session.Save(worker);
            }

            foreach (var worker in Workers)
            {
                Company.AddWorker(worker);
            }
            
            session.SaveOrUpdate(Company);
    
            transaction.Commit();
                
            Console.WriteLine("Данные успешно добавлены");
        }
    }
}

