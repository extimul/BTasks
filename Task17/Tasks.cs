using Task17.Data;
using Task17.Models;

namespace Task17;

public class Tasks
{
    public void Task1()
    {
        Console.WriteLine("1. Выберите из таблицы workers записи с name равным Дмитрий, Альберт, Артем.");
        var session = DbManager.OpenSession();

        string[] names = {"Дмитрий", "Альберт", "Артем" };
        
        var workers = session.Query<Worker>()
            .Where(x => names.Contains(x.Name))
            .Select(x => new {x.Name, x.Id})
            .ToList();
        
        foreach (var worker in workers)
        {
            Console.WriteLine($"Login: {worker.Id}; Name: {worker.Name}");
        }
    }

    public void Task2()
    {
        Console.WriteLine("2. Выберите из таблицы workers записи с login равным 'user1', 'user2', 'user3'");
        var session = DbManager.OpenSession();

        string[] logins = {"user1", "user2", "user3"};
        
        var workers = session.Query<Worker>()
            .Where(x => logins.Contains(x.Login))
            .Select(x => new {x.Login, x.Id})
            .ToList();
        
        foreach (var worker in workers)
        {
            Console.WriteLine($"Login: {worker.Id}; Login: {worker.Login}");
        }
    }
    
    public void Task3()
    {
        Console.WriteLine("3. Выберите из таблицы workers записи с name равным ‘Алина’, ‘Андрей’, ‘Виктория’, и логином, равным 'user', 'admin', 'ivan' и зарплатой больше 300.");
        var session = DbManager.OpenSession();

        string[] logins = { "user", "admin", "ivan" };
        string[] names = { "Алина", "Андрей", "Виктория" };
        
        var workers = session.Query<Worker>()
            .Where(x => logins.Contains(x.Login) && names.Contains(x.Name) && x.Salary > 300)
            .Select(x => new { x.Name, x.Login, x.Salary })
            .ToList();

        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker.Name}; Login: {worker.Login}; Salary: {worker.Salary}");
        }
    }
    
    public void Task4()
    {
        Console.WriteLine("4. Выберите из таблицы workers записи c зарплатой от 100 до 1000");
        var session = DbManager.OpenSession();

        var workers = session.Query<Worker>()
            .Where(x => x.Salary > 100 && x.Salary < 1000)
            .Select(x => new { x.Name, x.Login, x.Salary })
            .ToList();

        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker.Name}; Login: {worker.Login}; Salary: {worker.Salary}");
        }
    }

    private void Task5()
    {
        Console.WriteLine("5. Выберите из таблицы workers все записи так, чтобы туда попали только записи с разной зарплатой (без дублей)");
        var session = DbManager.OpenSession();

        var workers = session.Query<Worker>()
            .Select(x => new {x.Salary, x.Name})
            .ToList()
            .DistinctBy(x => x.Salary);
    
        Console.WriteLine("Зарплаты сотрудников");
        
        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker.Name}; Salary: {worker.Salary}");
        }
    }

    public void Task6()
    {
        Console.WriteLine("6. Получите все возрасты без дублирования");
        var session = DbManager.OpenSession();

        var workers = session.Query<Worker>()
            .Select(x => new {x.Age, x.Name})
            .ToList()
            .DistinctBy(x => x.Age);
    
        Console.WriteLine("Возраст сотрудников");
        
        foreach (var worker in workers)
        {
            Console.WriteLine($"Name: {worker.Name}; Age: {worker.Age}");
        }
    }
    
    public void Task7()
    {
        Console.WriteLine("7. Найдите в таблице workers минимальную зарплату");
        var session = DbManager.OpenSession();

        var minSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Min();

        Console.WriteLine($"Минимальная зарплата: {minSalary}");
    }
    
    public void Task8()
    {
        Console.WriteLine("8. Найдите в таблице workers минимальную зарплату");
        var session = DbManager.OpenSession();

        var maxSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Max();

        Console.WriteLine($"Максимальная зарплата: {maxSalary}");
    }
    
    public void Task9()
    {
        Console.WriteLine("9. Найдите в таблице workers суммарную зарплату");
        var session = DbManager.OpenSession();

        var totalSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Sum();
    
        Console.WriteLine($"Сумарная зарплата: {totalSalary}");
    }

    public void Task10()
    {
        Console.WriteLine("10. Найдите в таблице workers суммарную зарплату для людей в возрасте от 21 до 25");
        var session = DbManager.OpenSession();

        var totalSalary = session.Query<Worker>()
            .Where(x => x.Age > 21 && x.Age < 25)
            .Select(x => x.Salary)
            .Sum();
    
        Console.WriteLine($"Сумарная зарплата для людей в возрасте от 21 до 25: {totalSalary}");
    }
    
    public void Task11()
    {
        Console.WriteLine("11. Найдите в таблице workers среднюю зарплату");
        var session = DbManager.OpenSession();

        var avgSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Average();
    
        Console.WriteLine($"Средняя зарплата : {avgSalary}");
    }
    
    public void Task12()
    {
        Console.WriteLine("12. Найдите в таблице workers средний возраст");
        var session = DbManager.OpenSession();

        var avgAge = session.Query<Worker>()
            .Select(x => x.Age)
            .Average();
    
        Console.WriteLine($"Средний возраст: {avgAge}");
    }
    
    public void Task13()
    {
        Console.WriteLine("13. Выберите из таблицы workers все записи, у которых дата больше текущей");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Select(x => new {x.Name, x.Date})
            .Where(x => x.Date > DateTime.Now)
            .ToList();

        foreach (var record in records)   
        {
            Console.WriteLine($"Name: {record.Name}; Date: {record.Date.ToShortDateString()}");
        }
    }
    
    public void Task14()
    {
        Console.WriteLine("14. Вставьте в таблицу workers запись с полем date с текущим моментом времени в формате 'год-месяц-день часы:минуты:секунды'");
        var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();

        var workers = session.Query<Worker>()
            .Where(x => x.Login == "task14")
            .ToList();

        if (!workers.Any())
        {
            var newWorker = new Worker("Task14", "task14", 99999, 99, DateTime.Now);
            session.Save(newWorker);
        
            Console.WriteLine($"Новая запись: {newWorker}");
        }
        
        transaction.Commit();
    }
    
    public void Task15()
    {
        Console.WriteLine("15. Вставьте в таблицу workers запись с полем date с текущей датой в формате 'год-месяц-день'.");
        var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();

        var workers = session.Query<Worker>()
            .Where(x => x.Login == "task15")
            .ToList();

        if (!workers.Any())
        {
            var newWorker = new Worker("Task15", "task15", 99999, 99, DateTime.Now.Date);
            session.Save(newWorker);
        
            Console.WriteLine($"Новая запись: {newWorker}");
        }
        
        transaction.Commit();
    }
    
    public void Task16()
    {
        Console.WriteLine("16. Выберите из таблицы workers все записи за 2020 год");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Where(x => x.Date.Year == 2020)
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи за 2020г:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи за 2020г отсутствуют");
        }
    }
    
    public void Task17()
    {
        Console.WriteLine("17. Выберите из таблицы workers все записи за март любого года");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Where(x => x.Date.Month == 3)
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи за март любого года:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи за март любого года отсутствуют");
        }
    }
    
    public void Task18()
    {
        Console.WriteLine("18. Выберите из таблицы workers все записи за третий день месяца");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Where(x => x.Date.Day == 3)
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи за третий день месяца:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи за третий день месяца отсутствуют");
        }
    }
    
    public void Task19()
    {
        Console.WriteLine("19. Выберите из таблицы workers все записи за пятый день апреля любого года");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Where(x => x.Date.Day == 5 && x.Date.Month == 4)
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи за пятый день апреля любого года:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи за пятый день апреля любого года");
        }
    }
    
    public void Task20()
    {
        Console.WriteLine("20. Выберите из таблицы workers все записи за следующие дни любого месяца: 1, 7, 11, 12, 15, 19, 21, 29");
        var session = DbManager.OpenSession();

        int[] days = {1, 7, 11, 12, 15, 19, 21, 29};

        var records = session.Query<Worker>()
            .Where(x => days.Contains(x.Date.Day))
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи за следующие дни любого месяца: 1, 7, 11, 12, 15, 19, 21, 29:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи за следующие дни любого месяца: 1, 7, 11, 12, 15, 19, 21, 29 отсутствуют");
        }
    }
    
    public void Task21()
    {
        Console.WriteLine("21. Выберите из таблицы workers все записи, в которых день меньше месяца.");
        var session = DbManager.OpenSession();

        var records = session.Query<Worker>()
            .Where(x => x.Date.Day < x.Date.Month)
            .Select(x => new {x.Name, x.Date})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи в которых день меньше месяца:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Date: {record.Date}");
            }
        }
        else
        {
            Console.WriteLine("Записи в которых день меньше месяца отсутствуют");
        }
    }
    
    public void Task22()
    {
        Console.WriteLine("22. Найдите самые маленькие зарплаты по группам возрастов (для каждого возраста свою минимальную зарплату)");
        var session = DbManager.OpenSession();

        var groupedByAgeRecords = session.Query<Worker>()
            .GroupBy(x => x.Age)
            .ToList();

        foreach (var group in groupedByAgeRecords)
        {
            Console.WriteLine($"Возраст: {group.Key}");
            Console.WriteLine($"\tМинимальная зарплата: {group.Min(x => x.Salary)}");
        }
    }
    
    public void Task23()
    {
        Console.WriteLine("23. Найдите самый большой возраст по группам зарплат (для каждой зарплаты свой максимальный возраст)");
        var session = DbManager.OpenSession();

        var groupedBySalaryRecords = session.Query<Worker>()
            .GroupBy(x => x.Salary)
            .ToList();

        foreach (var group in groupedBySalaryRecords)
        {
            Console.WriteLine($"Зарплата: {group.Key}");
            Console.WriteLine($"\tМаксимальный возраст: {group.Max(x => x.Age)}");
        }
    }
    
    public void Task24()
    {
        Console.WriteLine("24. Выберите из таблицы workers все записи, зарплата в которых больше средней зарплаты.");
        var session = DbManager.OpenSession();

        var avgSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Average();
        
        Console.WriteLine($"Средняя зарплата: {avgSalary}");

        var records = session.Query<Worker>()
            .Where(x => x.Salary > avgSalary)
            .Select(x => new {x.Name, x.Salary})
            .ToList();
    
        if (records.Any())
        {
            Console.WriteLine($"Записи в которых зарплата больше средней зарплаты:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Salary: {record.Salary}");
            }
        }
        else
        {
            Console.WriteLine("Записи в которых зарплата больше средней зарплаты отсутствуют");
        }
    }
    
    public void Task25()
    {
        Console.WriteLine("25. Выберите из таблицы workers все записи, возраст в которых меньше среднего возраста, деленного на 2 и умноженного на 3.");
        var session = DbManager.OpenSession();

        var avgAge = session.Query<Worker>()
            .Select(x => x.Age)
            .Average();
        
        Console.WriteLine($"Средний возраст: {avgAge}");

        var records = session.Query<Worker>()
            .Where(x => x.Age > avgAge / 2 * 3)
            .Select(x => new { x.Name, x.Age })
            .ToList();
    
        if (records.Any())
        {
            Console.WriteLine($"Записи в которых возраст в которых меньше среднего возраста, деленного на 2 и умноженного на 3:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Age: {record.Age}");
            }
        }
        else
        {
            Console.WriteLine("Записи в которых возраст в которых меньше среднего возраста, деленного на 2 и умноженного на 3");
        }
    }
    
    public void Task26()
    {
        Console.WriteLine("26. Выберите из таблицы workers записи с минимальной зарплатой.");
        var session = DbManager.OpenSession();

        var minSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Min();
        
        Console.WriteLine($"Минимальная зарплата: {minSalary}");
        
        var records = session.Query<Worker>()
            .Where(x => x.Salary == minSalary)
            .Select(x => new {x.Name, x.Salary})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи с минимальной зарплатой:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Salary: {record.Salary}");
            }
        }
        else
        {
            Console.WriteLine("Записи с минимальной зарплатой отсутствуют");
        }
    }
    
    public void Task27()
    {
        Console.WriteLine("27. Выберите из таблицы workers записи с максимальной зарплатой.");
        var session = DbManager.OpenSession();

        var maxSalary = session.Query<Worker>()
            .Select(x => x.Salary)
            .Max();
        
        Console.WriteLine($"Максимальная зарплата: {maxSalary}");
        
        var records = session.Query<Worker>()
            .Where(x => x.Salary == maxSalary)
            .Select(x => new {x.Name, x.Salary})
            .ToList();

        if (records.Any())
        {
            Console.WriteLine($"Записи с максимальной зарплатой:");
            foreach (var record in records)
            {
                Console.WriteLine($"Name: {record.Name}; Salary: {record.Salary}");
            }
        }
        else
        {
            Console.WriteLine("Записи с максимальной зарплатой отсутствуют");
        }
    }
}