using FluentNHibernate.Mapping;
using Task17.Models;

namespace Task17.Mappings;

public class WorkerMap : ClassMap<Worker>
{
    public WorkerMap()
    {
        Table("workers");
        Id(x => x.Id);
        Map(x => x.Name);
        Map(x => x.Login);
        Map(x => x.Age);
        Map(x => x.Date);
        Map(x => x.Salary);
    }
}