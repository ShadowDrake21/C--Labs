using System.Collections.Generic;

namespace Lab3_individual_task
{
    public class Author : EntityBase
    {
        private IList<Book> bookList = new List<Book>();
        public virtual string AuthorName { get; set; }
        public virtual int BirthYear { get; set; }
        public virtual string Country { get; set; }
        public virtual string TheMostFamousBook { get; set; }
        public virtual IList<Book> BookList
        {
            get { return bookList; }
            set { bookList = value; }
        }
    }
}