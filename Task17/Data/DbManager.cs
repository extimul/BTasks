using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.NLog;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Task17.Data
{
    public static class DbManager
    {
        private static ISessionFactory _sessionFactory;
    
        private static ISessionFactory SessionFactory
        {
            get
            {
                NameValueCollection properties = new NameValueCollection();
                properties["configType"] = "FILE";
                properties["configFile"] = "~\\NLog.config";
                LogManager.Adapter = new NLogLoggerFactoryAdapter(properties);
                
                var configuration = new Configuration();
                configuration.Configure("Configuration\\hibernate.cfg.xml");
                configuration.AddAssembly(typeof(Program).Assembly);
                BuildSchema(configuration);
                _sessionFactory = configuration.BuildSessionFactory();
            
                return _sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private static void BuildSchema(Configuration config)
        {
            new SchemaUpdate(config)
                .Execute(true, true);
        }
    }
}
