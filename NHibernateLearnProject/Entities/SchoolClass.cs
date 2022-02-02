namespace NHibernateLearnProject.Entities;

public class SchoolClass
{
    public virtual Guid Id { get; protected set; }
    public virtual string? ClassTitle { get; set; }
    
    private IList<Student> _students;
    public virtual IList<Student> Students {
        get {
            return _students ??= new List<Student>();
        }
        set => _students = value;
    }

    public virtual void AddStudent(params Student[] students)
    {
        foreach (var student in students)
        {
            student.SchoolClass = this;
            Students?.Add(student);
        }
    }
}