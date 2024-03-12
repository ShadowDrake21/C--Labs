namespace Lab4_task_work.Dao
{
    abstract public class DAOFactory
    {
        public abstract IBookDAO getBookDAO();
        public abstract void destroy();
    }
}