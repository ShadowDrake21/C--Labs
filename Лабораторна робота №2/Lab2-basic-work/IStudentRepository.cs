using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_basic_work
{
    interface IStudentRepository
    {
        public void Save(Student student);
        public void Update(Student student);
        public IList<Student> GetAll();
        public Student FindById(long id);
        public void Delete(long id);
        public void Destroy();
    }
}