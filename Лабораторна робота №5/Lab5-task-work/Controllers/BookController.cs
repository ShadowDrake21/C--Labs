using Microsoft.AspNetCore.Mvc;
using Lab5_task_work.Dao;
using Lab5_task_work.Domain;

namespace Lab5_task_work.Controllers
{
    [ApiController]
    [Route("book")]
    public class BookController : ControllerBase
    {
        //Сервіс для виводу всіх книг
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IList<Book> GetAllStudents()
        {
            IList<Book> books = NHibernateDAOFactory
            .getInstance().getBookDAO().GetAll();
            return books;
        }
        //Сервіс для додавання нової книги
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Book AddStudent(Book book)
        {
            Book resultBook = NHibernateDAOFactory
            .getInstance().getBookDAO().Merge(book);
            return resultBook;
        }
        //Сервіс для редагування книги
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Book UpdateStudent(Book book)
        {
            Book resultBook = NHibernateDAOFactory
            .getInstance().getBookDAO().Merge(book);
            return resultBook;
        }
        //Сервіс для видалення книги
        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("{id}")]
        public string Delete(long id)
        {
            string result;
            Book book = NHibernateDAOFactory
            .getInstance().getBookDAO().GetById(id);
            if (null != book)
            {
                NHibernateDAOFactory.getInstance()
                .getBookDAO().Delete(book);
                result = "Book was successfully removed.";
            }
            else
            {
                result = "Nothing was removed.";
            }
            return result;
        }
    }
}