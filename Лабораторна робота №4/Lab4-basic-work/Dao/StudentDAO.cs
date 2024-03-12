using ISession = NHibernate.ISession;
using Lab4_basic_work.Domain;

namespace Lab4_basic_work.Dao
{
    public class StudentDAO : GenericDAO<Student>, IStudentDAO
    {
        public StudentDAO(ISession session) : base(session) { }
    }
}