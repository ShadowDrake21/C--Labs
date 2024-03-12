namespace Lab4_basic_work.Dao
{
    public interface IGenericDAO<T>
    {
        void SaveOrUpdate(T item);
        T GetById(long id);
        List<T> GetAll();
        void Delete(T item);
    }
}