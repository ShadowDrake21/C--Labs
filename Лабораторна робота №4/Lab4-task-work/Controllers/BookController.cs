using Microsoft.AspNetCore.Mvc;
using Lab4_task_work.Domain;
using Lab4_task_work.Dao;

namespace Lab4_task_work.Controllers;
public class BookController : Controller
{
  //Обробник виводу головної сторінки
  public IActionResult GetAll()
  {
    List<Book> bookList = NHibernateDAOFactory
    .getInstance().getBookDAO().GetAll();
    return View(bookList);
  }
  //Обробник додання студента
  [HttpPost]
  public IActionResult Add(
  [Bind("Title, Author, Year, CanBeTakenHome")] Book book)
  {
    NHibernateDAOFactory.getInstance()
    .getBookDAO().SaveOrUpdate(book);
    return RedirectToAction("GetAll");
  }
  //Обробник відкриття форми редагування студента
  [Route("EditForm/{id}")]
  public IActionResult EditForm(long id)
  {
    Book book = NHibernateDAOFactory
    .getInstance().getBookDAO().GetById(id);
    return View(book);
  }
  //Обробник редагування студента
  [HttpPost]
  public IActionResult Edit(
  [Bind("Id, Title, Author, Year, CanBeTakenHome")] Book book)
  {
    Book bookToUpdate = NHibernateDAOFactory
    .getInstance().getBookDAO().GetById(book.Id);
    bookToUpdate.Title = book.Title;
    bookToUpdate.Author = book.Author;
    bookToUpdate.Year = book.Year;
    bookToUpdate.CanBeTakenHome = book.CanBeTakenHome;
    NHibernateDAOFactory.getInstance()
    .getBookDAO().SaveOrUpdate(bookToUpdate);
    return RedirectToAction("GetAll");
  }
  //Обробник видалення студента
  [Route("Delete/{id}")]
  public IActionResult Delete(long id)
  {
    Book book = NHibernateDAOFactory
    .getInstance().getBookDAO().GetById(id);
    NHibernateDAOFactory.getInstance()
    .getBookDAO().Delete(book);
    return RedirectToAction("GetAll");
  }
}