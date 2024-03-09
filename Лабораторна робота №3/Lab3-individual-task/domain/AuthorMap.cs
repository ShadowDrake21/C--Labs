using FluentNHibernate.Mapping;

namespace Lab3_individual_task
{
    public class AuthorMap : ClassMap<Author>
    {
        public AuthorMap()
        {
            Table("Authors");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.AuthorName);
            Map(x => x.BirthYear);
            Map(x => x.Country);
            Map(x => x.TheMostFamousBook);
            HasMany(x => x.BookList).Cascade.All().KeyColumn("AuthorId");
        }
    }
}