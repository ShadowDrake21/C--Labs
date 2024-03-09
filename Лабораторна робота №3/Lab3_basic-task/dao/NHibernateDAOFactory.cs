using System;
using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Lab3_basic_task
{
    public class NHibernateDAOFactory : DAOFactory
    {
        private static ISessionFactory factory;
        private static DAOFactory instance;
        private ISession session;
        private IGroupDAO groupDAO;
        private IStudentDAO studentDAO;
        public static DAOFactory getInstance()
        {
            if (null == instance)
            {
                ISession session = openSession("127.0.0.1", Convert.ToInt32("5432"), "universityorm", "postgres", "111111");
                instance = new NHibernateDAOFactory(session);
            }
            return instance;
        }
        public NHibernateDAOFactory(ISession session)
        {
            this.session = session;
        }
        public override IGroupDAO getGroupDAO()
        {
            if (null == groupDAO)
            {
                groupDAO = new GroupDAO(session);
            }
            return groupDAO;
        }
        public override IStudentDAO getStudentDAO()
        {
            if (null == studentDAO)
            {
                studentDAO = new StudentDAO(session);
            }
            return studentDAO;
        }
        public override void destroy()
        {
            session.Close();
        }
        private static ISession openSession(String host, int port, String database, String user, String password)
        {
            ISession session = null;
            Assembly mappingsAssembly = Assembly.GetExecutingAssembly();
            if (null == factory)
            {
                factory = Fluently.Configure().Database(PostgreSQLConfiguration.PostgreSQL82.ConnectionString(c => c.Host(host).Port(port).Database(database).Username(user).Password(password))).Mappings(m => m.FluentMappings.AddFromAssembly(mappingsAssembly)).ExposeConfiguration(BuildSchema).BuildSessionFactory();
            }
            session = factory.OpenSession();
            return session;
        }
        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(true, false);
        }
    }
}