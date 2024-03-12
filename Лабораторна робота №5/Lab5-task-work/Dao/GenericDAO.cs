using NHibernate;
using ISession = NHibernate.ISession;

namespace Lab5_task_work.Dao
{
    public class GenericDAO<T> : IGenericDAO<T>
    {
        protected ISession session;
        public GenericDAO() { }
        public GenericDAO(ISession session)
        {
            this.session = session;
        }
        public T Merge(T item)
        {
            ITransaction transaction = session.BeginTransaction();
            T resultItem = (T)session.Merge(item);
            transaction.Commit();
            return resultItem;
        }
        public T GetById(long id)
        {
            return session.Get<T>(id);
        }
        public List<T> GetAll()
        {
            return new List<T>(session.CreateCriteria(typeof(T)).List<T>());
        }
        public void Delete(T item)
        {
            ITransaction transaction = session.BeginTransaction();
            session.Delete(item);
            transaction.Commit();
        }
    }
}