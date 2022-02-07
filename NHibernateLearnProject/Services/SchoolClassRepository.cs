using NHibernate.Criterion;
using NHibernateLearnProject.Data;
using NHibernateLearnProject.Entities;
using System.Linq;
using NHibernate.Linq;

namespace NHibernateLearnProject.Services;

public static class SchoolClassRepository
{
    public static async Task AddSchoolClass(SchoolClass schoolClass)
    {
        using var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();
        
        await session.SaveAsync(schoolClass);
        await transaction.CommitAsync();
    }
    
    public static async Task AddStudentsAsync(Guid classId, params Student[] students)
    {
        using var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();

        var schoolClass = session.Query<SchoolClass>().FirstOrDefault(x => x.Id == classId);
        if (schoolClass != null)
        {
            schoolClass.AddStudent(students);
        }

        await session.SaveOrUpdateAsync(schoolClass);
        await transaction.CommitAsync();
    }

    public static SchoolClass GetById(Guid schoolClassId)
    {
        using var session = DbManager.OpenSession();
        return session.Get<SchoolClass>(schoolClassId);
    }

    public static SchoolClass? GetByName(string className)
    {
        // var session = DbManager.OpenSession();
        // var schoolClass = session
        //     .Query<SchoolClass>()
        //     .FirstOrDefault(x => x.ClassTitle == className);
        // return schoolClass;

        var session = DbManager.OpenSession();
        using var transaction = session.BeginTransaction();
        var schoolClasses = session.CreateQuery($"select cl from SchoolClass cl where cl.ClassTitle = '{className}'");
        return schoolClasses.List<SchoolClass>().FirstOrDefault();
    }

    public static async Task<List<SchoolClass>> GetAllClassesAsync()
    {
        var session = DbManager.OpenSession();
        return await session.Query<SchoolClass>().ToListAsync();
    }

    public static void Task19()
    {
        var session = DbManager.OpenSession();

        var students =
            session.Query<Student>()
                .Where(x => x.SchoolClass.ClassTitle.Like("1%"))
                .Where(x =>
                    session.Query<Student>()
                        .Where(student => student.FirstName.Like("I%"))
                        .Select(student => student.FirstName)
                        .Contains(x.FirstName))
                .ToList();

        foreach (var student in students)
        {
            Console.WriteLine($"{student.FirstName} {student.LastName}");
        }

    }
}