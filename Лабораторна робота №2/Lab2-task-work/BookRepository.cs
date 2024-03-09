using System.Collections;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Lab2_task_work
{
    class BookRepository : IBookRepository
    {
        private BookRepository() { }

        private NpgsqlConnection connection;
        private static IBookRepository instance;
        public static IBookRepository getInstance()
        {
            if (null == instance)
            {
                instance = new BookRepository();
            }
            return instance;
        }

        private NpgsqlConnection getConnection()
        {
            if (null == connection)
            {
                String connectionStr = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=111111;Database=library;";
                connection = new NpgsqlConnection(connectionStr);
                connection.Open();
            }
            return connection;
        }
        public Book FindById(long id)
        {
            DbCommand command = NpgsqlFactory.Instance.CreateCommand();
            command.Connection = getConnection();
            command.CommandText = "SELECT * FROM books WHERE id = @id";
            addParameterToCommand(command, "@id", DbType.Int64, id);
            DbDataReader row = command.ExecuteReader();
            Book book = null;
            while (row.Read())
            {
                long bookId = (long)row["id"];
                String title = (String)row["title"];
                String author = (String)row["author"];
                int year = (int)row["publishYear"];
                bool canBeTakenHome = (bool)row["canBeTakenHome"];
                book = new Book();
                book.Title = title;
                book.Author = author;
                book.Year = year;
                book.CanBeTakenHome = canBeTakenHome;
            }
            row.Close();
            return book;
        }
        public IList<Book> GetAll()
        {
            IList<Book> bookList = new List<Book>();
            DbCommand command = NpgsqlFactory.Instance.CreateCommand();
            command.Connection = getConnection();
            command.CommandText = "SELECT * FROM books";
            DbDataReader row = command.ExecuteReader();
            while (row.Read())
            {
                long id = (long)row["id"];
                String title = (String)row["title"];
                String author = (String)row["author"];
                int year = (int)row["publishYear"];
                bool canBeTakenHome = (bool)row["canBeTakenHome"];
                Book book = new Book();
                book.Id = id;
                book.Title = title;
                book.Author = author;
                book.Year = year;
                book.CanBeTakenHome = canBeTakenHome;
                bookList.Add(book);
            }
            row.Close();
            return bookList;
        }
        public void Save(Book book)
        {
            DbCommand command = NpgsqlFactory.Instance.CreateCommand();
            command.Connection = getConnection();
            command.CommandText = "INSERT INTO books(title, author, publishYear, canBeTakenHome) VALUES(@title, @author, @year, @canBeTakenHome)";
            addParameterToCommand(command, "@title", DbType.String, book.Title);
            addParameterToCommand(command, "@author", DbType.String, book.Author);
            addParameterToCommand(command, "@year", DbType.Int32, book.Year);
            addParameterToCommand(command, "@canBeTakenHome", DbType.Boolean, book.CanBeTakenHome);
            command.ExecuteNonQuery();
        }
        public void Update(Book book)
        {
            DbCommand command = NpgsqlFactory.Instance.CreateCommand();
            command.Connection = getConnection();
            command.CommandText = "UPDATE books SET title=@title, author=@author, publishYear=@year, canBeTakenHome=@canBeTakenHome WHERE id=@id";
            addParameterToCommand(command, "@id", DbType.Int64, book.Id);
            addParameterToCommand(command, "@title", DbType.String, book.Title);
            addParameterToCommand(command, "@author", DbType.String, book.Author);
            addParameterToCommand(command, "@year", DbType.Int32, book.Year);
            addParameterToCommand(command, "@canBeTakenHome", DbType.Boolean, book.CanBeTakenHome);
            command.ExecuteNonQuery();
        }
        public void Delete(long id)
        {
            DbCommand command = NpgsqlFactory.Instance.CreateCommand();
            command.Connection = getConnection();
            command.CommandText = "DELETE FROM books WHERE id=@id";
            addParameterToCommand(command, "@id", DbType.Int64, id);
            command.ExecuteNonQuery();
        }

        public void LoadFromJson(string path)
        {
            try
            {
                string json = System.IO.File.ReadAllText(path);
                IList<Book> books = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Book>>(json);
                foreach (var book in books)
                {
                    Save(book);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public void addParameterToCommand(DbCommand command, string parameterName, DbType parameterType, object parameterValue)
        {
            NpgsqlParameter parameter = new NpgsqlParameter();
            parameter.ParameterName = parameterName;
            parameter.DbType = parameterType;
            parameter.Value = parameterValue;
            command.Parameters.Add(parameter);
        }
        public void Destroy()
        {
            getConnection().Close();
        }
    }
}