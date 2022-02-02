using FluentNHibernate.Mapping;
using NHibernateLearnProject.Entities;

namespace NHibernateLearnProject.Mappings;

public class SchoolClassMap : ClassMap<SchoolClass>
{
    public SchoolClassMap()
    {
        Id(x => x.Id);
        Map(x => x.ClassTitle);
        HasMany(x => x.Students)
            .Cascade.All();
    }
}