using System.Collections.Generic;
using NHibernate;

namespace Lab3_individual_task
{
    public class BookDAO : GenericDAO<Book>, IBookDAO
    {
        public BookDAO(ISession session) : base(session) { }
        public IList<Book> getBooksByAuthor(long authorId)
        {
            var list = session.CreateSQLQuery("SELECT Books.* FROM Books JOIN Authors" + " ON Books.AuthorId = Authors.Id" + " WHERE Authors.Id=" + authorId).AddEntity("Book", typeof(Book)).List<Book>();
            return list;
        }
    }
}