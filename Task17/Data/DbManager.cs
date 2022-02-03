using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Task17.Data;

public static class DbManager
{
    private const string DbFile = "task17.db";

    private static ISessionFactory _sessionFactory;
    
    private static ISessionFactory SessionFactory
    {
        get
        {
            _sessionFactory = Fluently.Configure()
                .Database(SQLiteConfiguration.Standard
                    .UsingFile(DbFile))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
            
            return _sessionFactory;
        }
    }

    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }

    private static void BuildSchema(Configuration config)
    {
        // if (File.Exists(DbFile))
        //     File.Delete(DbFile);
        
        new SchemaUpdate(config)
            .Execute(true, true);
    }
}