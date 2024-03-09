using NHibernate;

namespace Lab3_basic_task
{
    public class GroupDAO : GenericDAO<Group>, IGroupDAO
    {
        public GroupDAO(ISession session) : base(session) { }
    }
}