namespace Task17.Models;

public class Company
{
    public virtual Guid Id { get; protected set; }
    
    public virtual string Name { get; set; }
    
    private IList<Worker> _workers;
    
    public virtual IList<Worker> Workers {
        get {
            return _workers ??= new List<Worker>();
        }
        set => _workers = value;
    }
    
    public Company() {}

    public Company(string name)
    {
        Name = name;
    }

    public virtual void AddWorker(Worker worker)
    {
        worker.Company = this;
        Workers?.Add(worker);
    }
}