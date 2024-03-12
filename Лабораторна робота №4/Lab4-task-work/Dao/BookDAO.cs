using ISession = NHibernate.ISession;
using Lab4_task_work.Domain;

namespace Lab4_task_work.Dao
{
    public class BookDAO : GenericDAO<Book>, IBookDAO
    {
        public BookDAO(ISession session) : base(session) { }
    }
}