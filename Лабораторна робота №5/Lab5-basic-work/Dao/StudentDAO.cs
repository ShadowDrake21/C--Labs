using Lab5_basic_work.Domain;
using ISession = NHibernate.ISession;

namespace Lab5_basic_work.Dao
{
    public class StudentDAO : GenericDAO<Student>, IStudentDAO
    {
        public StudentDAO(ISession session) : base(session) { }
    }
}