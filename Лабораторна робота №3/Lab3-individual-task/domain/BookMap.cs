using FluentNHibernate.Mapping;

namespace Lab3_individual_task
{
    public class BookMap : ClassMap<Book>
    {
        public BookMap()
        {
            Table("Books");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Title);
            Map(x => x.PublishingYear);
            Map(x => x.Language);
            Map(x => x.CountPages);
            References(x => x.Author, "AuthorId");
        }
    }
}