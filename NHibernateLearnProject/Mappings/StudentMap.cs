using FluentNHibernate.Mapping;
using NHibernateLearnProject.Entities;

namespace NHibernateLearnProject.Mappings;

public class StudentMap : ClassMap<Student>
{
    public StudentMap()
    {
        Id(x => x.Id);
        Map(x => x.FirstName);
        Map(x => x.LastName);
        References(x => x.SchoolClass);
    }
}