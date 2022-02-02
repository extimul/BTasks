using NHibernateLearnProject.Entities;
using NHibernateLearnProject.Services;

namespace NHibernateLearnProject.Data;

public static class DbInitializer
{
    public static async Task RunAsync()
    {
        using var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();
        
        var a1 = new SchoolClass() { ClassTitle = "1a" };
        var b1 = new SchoolClass() { ClassTitle = "1б" };

        var student1 = new Student() { FirstName = "Ivan", LastName = "Ivanov" };
        var student2 = new Student() { FirstName = "Petr", LastName = "Petrov" };
        var student3 = new Student() { FirstName = "Dmitriy", LastName = "Dmitriev" };
        
        a1.AddStudent(student1, student3);
        b1.AddStudent(student2);
                
        await session.SaveOrUpdateAsync(a1);
        await session.SaveOrUpdateAsync(b1);
                
        await transaction.CommitAsync();
    }
}