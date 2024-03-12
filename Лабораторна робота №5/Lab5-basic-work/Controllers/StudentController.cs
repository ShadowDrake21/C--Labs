using Microsoft.AspNetCore.Mvc;
using Lab5_basic_work.Dao;
using Lab5_basic_work.Domain;

namespace Lab5_basic_work.Controllers
{
    [ApiController]
    [Route("student")]
    public class StudentController : ControllerBase
    {
        //Сервіс для виводу всіх студентів
        [HttpGet]
        [Consumes("application/json")]
        [Produces("application/json")]
        public IList<Student> GetAllStudents()
        {
            IList<Student> students = NHibernateDAOFactory
            .getInstance().getStudentDAO().GetAll();
            return students;
        }
        //Сервіс для додавання нового студента
        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Student AddStudent(Student student)
        {
            Student resultStudent = NHibernateDAOFactory
            .getInstance().getStudentDAO().Merge(student);
            return resultStudent;
        }
        //Сервіс для редагування студента
        [HttpPut]
        [Consumes("application/json")]
        [Produces("application/json")]
        public Student UpdateStudent(Student student)
        {
            Student resultStudent = NHibernateDAOFactory
            .getInstance().getStudentDAO().Merge(student);
            return resultStudent;
        }
        //Сервіс для видалення студента
        [HttpDelete]
        [Consumes("application/json")]
        [Produces("application/json")]
        [Route("{id}")]
        public string Delete(long id)
        {
            string result;
            Student student = NHibernateDAOFactory
            .getInstance().getStudentDAO().GetById(id);
            if (null != student)
            {
                NHibernateDAOFactory.getInstance()
                .getStudentDAO().Delete(student);
                result = "Student was successfully removed.";
            }
            else
            {
                result = "Nothing was removed.";
            }
            return result;
        }
    }
}