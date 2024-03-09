namespace Lab3_basic_task
{
    abstract public class DAOFactory
    {
        public abstract IStudentDAO getStudentDAO();
        public abstract IGroupDAO getGroupDAO();
        public abstract void destroy();
    }
}