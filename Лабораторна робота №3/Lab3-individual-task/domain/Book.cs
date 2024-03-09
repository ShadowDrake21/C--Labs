namespace Lab3_individual_task
{
    public class Book : EntityBase
    {
        public virtual string Title { get; set; }
        public virtual int PublishingYear { get; set; }
        public virtual string Language { get; set; }
        public virtual int CountPages { get; set; }
        public virtual Author Author { get; set; }
    }
}