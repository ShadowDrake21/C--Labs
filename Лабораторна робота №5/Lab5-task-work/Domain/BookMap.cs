using FluentNHibernate.Mapping;

namespace Lab5_task_work.Domain
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("Books");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Title);
            Map(x => x.Author);
            Map(x => x.Year);
            Map(x => x.CanBeTakenHome);
        }
    }
}