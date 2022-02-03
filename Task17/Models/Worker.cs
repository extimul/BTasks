namespace Task17.Models;

public class Worker
{
    public virtual Guid Id { get; protected set; }
    
    public virtual string Name { get; set; }
    
    public virtual string Login { get; set; }
    
    public virtual decimal Salary { get; set; }
    
    public virtual int Age { get; set; }
    
    public virtual DateTime Date { get; set; }

    public Worker() {}
    
    public Worker(string name, string login, decimal salary, int age, DateTime date)
    {
        Name = name;
        Login = login;
        Salary = salary;
        Age = age;
        Date = date;
    }

    public override string ToString()
    {
        return $"ID: {Id}; Name: {Name}; Login: {Login}; Salary: {Salary}; Age: {Age}; Date: {Date}";
    }
}