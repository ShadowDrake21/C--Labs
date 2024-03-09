namespace Lab3_individual_task
{
    abstract public class DAOFactory
    {
        public abstract IBookDAO getBookDAO();
        public abstract IAuthorDAO getAuthorDAO();
        public abstract void destroy();
    }
}