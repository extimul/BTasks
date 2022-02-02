namespace NHibernateLearnProject.Entities;

public class Student
{
    public virtual Guid Id { get; protected set; }
    
    public virtual string FirstName { get; set; }
    
    public virtual string LastName { get; set; }
    
    public virtual SchoolClass SchoolClass { get; set; }
}