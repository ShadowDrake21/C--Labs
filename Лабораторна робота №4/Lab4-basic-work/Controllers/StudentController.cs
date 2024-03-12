using Microsoft.AspNetCore.Mvc;
using Lab4_basic_work.Domain;
using Lab4_basic_work.Dao;

namespace Lab4_basic_work.Controllers;
public class StudentController : Controller
{
    //Обробник виводу головної сторінки
    public IActionResult GetAll()
    {
        List<Student> studentList = NHibernateDAOFactory
        .getInstance().getStudentDAO().GetAll();
        return View(studentList);
    }
    //Обробник додання студента
    [HttpPost]
    public IActionResult Add(
    [Bind("FirstName, LastName, Sex, Year")] Student student)
    {
        NHibernateDAOFactory.getInstance()
        .getStudentDAO().SaveOrUpdate(student);
        return RedirectToAction("GetAll");
    }
    //Обробник відкриття форми редагування студента
    [Route("EditForm/{id}")]
    public IActionResult EditForm(long id)
    {
        Student student = NHibernateDAOFactory
        .getInstance().getStudentDAO().GetById(id);
        return View(student);
    }
    //Обробник редагування студента
    [HttpPost]
    public IActionResult Edit(
    [Bind("Id, FirstName, LastName, Sex, Year")] Student student)
    {
        Student studentToUpdate = NHibernateDAOFactory
        .getInstance().getStudentDAO().GetById(student.Id);
        studentToUpdate.FirstName = student.FirstName;
        studentToUpdate.LastName = student.LastName;
        studentToUpdate.Sex = student.Sex;
        studentToUpdate.Year = student.Year;
        NHibernateDAOFactory.getInstance()
        .getStudentDAO().SaveOrUpdate(studentToUpdate);
        return RedirectToAction("GetAll");
    }
    //Обробник видалення студента
    [Route("Delete/{id}")]
    public IActionResult Delete(long id)
    {
        Student student = NHibernateDAOFactory
        .getInstance().getStudentDAO().GetById(id);
        NHibernateDAOFactory.getInstance()
        .getStudentDAO().Delete(student);
        return RedirectToAction("GetAll");
    }
}