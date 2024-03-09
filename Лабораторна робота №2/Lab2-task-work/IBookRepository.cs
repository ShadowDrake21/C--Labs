using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab2_task_work
{
    interface IBookRepository
    {
        public void Save(Book book);
        public void Update(Book book);
        public IList<Book> GetAll();
        public void Delete(long id);

        // defence
        public void LoadFromJson(string path);
        // defence

        public void Destroy();
    }
}