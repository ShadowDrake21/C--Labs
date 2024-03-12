using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab5_basic_work.Domain
{
    public class Student : EntityBase
    {
        public virtual string? FirstName { get; set; }
        public virtual string? LastName { get; set; }
        public virtual char Sex { get; set; }
        public virtual int Year
        {
            get; set;
        }
    }
}