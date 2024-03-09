using System.Collections.Generic;

namespace Lab3_individual_task
{
    public interface IBookDAO : IGenericDAO<Book>
    {
        IList<Book> getBooksByAuthor(long authorId);
    }
}