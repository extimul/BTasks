using System.Reflection;
using NHibernateLearnProject.Data;
using NHibernateLearnProject.Entities;
using NHibernateLearnProject.Services;

namespace NHibernateLearnProject;

class Program
{
    private static async Task Main()
    {
        // Console.WriteLine("Начальная инициализация бд");
        // await DbInitializer.RunAsync();
        // Console.WriteLine("Окончание инциализации");
        // Console.WriteLine(new string('-', 60));
        // await DisplayAllSchoolClasses();
        // Console.WriteLine(new string('-', 60));
        // await AddNewClass();
        // Console.WriteLine(new string('-', 60));
        // await DisplayAllSchoolClasses();

        var a1 = SchoolClassRepository.GetByName("1a");
        Console.WriteLine(a1?.ClassTitle);
    }

    private static async Task AddNewClass()
    {
        Console.WriteLine("Добавляем новый класс и ученика в БД");
        SchoolClass newSchoolClass = new()
        {
            ClassTitle = "9а",
        };
        
        await SchoolClassRepository.AddSchoolClass(newSchoolClass);

        Student newStudent = new()
        {
            FirstName = "Vasiliy",
            LastName = "Ivanov",
        };
        
        await SchoolClassRepository.AddStudentsAsync(newSchoolClass.Id, newStudent);
    }

    private static async Task DisplayAllSchoolClasses()
    {
        Console.WriteLine("Получаем данные из БД");
        var classes = await SchoolClassRepository.GetAllClassesAsync();
        foreach (var schoolClass in classes)
        {
            Console.WriteLine($"Класс: Id {schoolClass?.Id}, Название {schoolClass?.ClassTitle}");
            Console.WriteLine("Ученики класса:");

            if (schoolClass?.Students is null) continue;
            
            foreach (var student in schoolClass.Students)
            {
                Console.WriteLine($"\tИмя: {student.FirstName}, Фамилия {student.LastName}");
            }

            Console.WriteLine();
        }
    }
}

