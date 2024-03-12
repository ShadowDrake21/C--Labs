namespace Lab5_basic_work.Dao
{
    abstract public class DAOFactory
    {
        public abstract IStudentDAO getStudentDAO();
        public abstract void destroy();
    }
}