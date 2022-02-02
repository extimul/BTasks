using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace NHibernateLearnProject.Data;

public static class DbManager
{
    private const string DbFile = "school.db";

    private static ISessionFactory _sessionFactory;
    
    private static ISessionFactory SessionFactory
    {
        get
        {
            if(_sessionFactory is null)
            {
                //Fluent - PostgreSQL
                // _sessionFactory = Fluently.Configure()
                //     .Database(PostgreSQLConfiguration.Standard
                //         .ConnectionString(c => 
                //             c.Host("server")
                //                 .Port(5432)
                //                 .Database("database")
                //                 .Username("username")
                //                 .Password("password")))
                //     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                //     .ExposeConfiguration(BuildSchema)
                //     .BuildSessionFactory();
                
                // Fluent - SQLite
                // _sessionFactory = Fluently.Configure()
                //     .Database(SQLiteConfiguration.Standard.UsingFile(DbFile))
                //     .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Program>())
                //     .ExposeConfiguration(BuildSchema)
                //     .BuildSessionFactory();
                
                // XML - SQLite
                var configuration = new Configuration();
                configuration.Configure("Configuration\\hibernate.cfg.xml");
                configuration.AddAssembly(typeof(Program).Assembly);
                new SchemaUpdate(configuration).Execute(true, true);
                _sessionFactory = configuration.BuildSessionFactory();
            }
            return _sessionFactory;
        }
    }
    
    public static ISession OpenSession()
    {
        return SessionFactory.OpenSession();
    }

    private static void BuildSchema(Configuration config)
    {
        if (File.Exists(DbFile))
            File.Delete(DbFile);
        
        new SchemaExport(config)
            .Create(false, true);
    }
}