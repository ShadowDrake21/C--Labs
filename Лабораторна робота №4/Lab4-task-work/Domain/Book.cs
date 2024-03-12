namespace Lab4_task_work.Domain
{
    public class Book : EntityBase
    {
        public virtual string Title { get; set; }
        public virtual string Author { get; set; }
        public virtual int Year { get; set; }
        public virtual bool CanBeTakenHome { get; set; }
    }
}
