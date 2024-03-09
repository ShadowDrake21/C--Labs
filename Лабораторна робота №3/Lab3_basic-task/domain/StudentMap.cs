using FluentNHibernate.Mapping;

namespace Lab3_basic_task
{
    public class StudentMap : ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Students");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.FirstName);
            Map(x => x.LastName);
            Map(x => x.Sex);
            Map(x => x.Year);
            References(x => x.Group, "GroupId");
        }
    }
}