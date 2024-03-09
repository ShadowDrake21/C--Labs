namespace Lab3_basic_task
{
    public interface IStudentDAO : IGenericDAO<Student>
    {
        IList<Student> getStudentsByGroup(long groupId);
    }
}