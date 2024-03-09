using NHibernate;

namespace Lab3_individual_task
{
    public class AuthorDAO : GenericDAO<Author>, IAuthorDAO
    {
        public AuthorDAO(ISession session) : base(session) { }
    }
}