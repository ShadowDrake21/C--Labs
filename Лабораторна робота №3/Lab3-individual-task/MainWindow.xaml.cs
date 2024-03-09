using System.ComponentModel;
using System.Windows;
namespace Lab3_individual_task
{
    public partial class MainWindow : Window
    {
        private DAOFactory daoFactory;
        public DAOFactory getDaoFactory()
        {
            if (null == daoFactory)
            {
                daoFactory = NHibernateDAOFactory.getInstance();
            }
            return daoFactory;
        }
        private AuthorWindow authorWindow;
        private BookWindow bookWindow;
        public AuthorWindow getAuthorWindow()
        {
            if (null == authorWindow)
            {
                authorWindow = new AuthorWindow(this);
            }
            return authorWindow;
        }
        public BookWindow getBookWindow()
        {
            if (null == bookWindow)
            {
                bookWindow = new BookWindow(this);
            }
            return bookWindow;
        }
        public MainWindow()
        {
            this.Closing += new CancelEventHandler(MainWindow_Closing);
            InitializeComponent();
            AuthorGrid.ItemsSource = getDaoFactory().getAuthorDAO().GetAll();
        }
        //Обробник натиснення на контекстне меню додання групи
        private void MenuItemAddAuthor_Click(object sender, EventArgs e)
        {
            AuthorWindow authorWindow = getAuthorWindow();
            authorWindow.AddButton.IsEnabled = true;
            authorWindow.CancelButton.IsEnabled = true;
            authorWindow.ShowDialog();
        }
        //Обробник натиснення на контекстне меню редагування групи
        private void MenuItemEditAuthor_Click(object sender, EventArgs e)
        {
            Author author = (Author)AuthorGrid.SelectedItem;
            if (null == author)
            {
                MessageBox.Show("Please select an author", "Nothing to edit",
                MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.No);
            }
            else
            {
                AuthorWindow authorWindow = getAuthorWindow();
                authorWindow.EditButton.IsEnabled = true;
                authorWindow.CancelButton.IsEnabled = true;
                authorWindow.Author = author;
                authorWindow.InputTextBox1.Text = author.AuthorName;
                authorWindow.InputTextBox2.Text = author.BirthYear.ToString();
                authorWindow.InputTextBox3.Text = author.Country;
                authorWindow.InputTextBox4.Text = author.TheMostFamousBook;
                authorWindow.ShowDialog();
            }
        }
        //Обробник натиснення на контекстне меню видалення групи
        private void MenuItemDeleteAuthor_Click(object sender, EventArgs e)
        {
            Author author = (Author)AuthorGrid.SelectedItem;
            if (null == author)
            {
                MessageBox.Show("Please select author", "Nothing to delete",
                MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.No);
            }
            else
            {
                getDaoFactory().getAuthorDAO().Delete(author);
                AuthorGrid.ItemsSource =
                getDaoFactory().getAuthorDAO().GetAll();
            }
        }
        //Обробник натиснення на контекстне меню додання студента
        private void MenuItemAddBook_Click(object sender, EventArgs e)
        {
            Author author = (Author)AuthorGrid.SelectedItem;
            if (null == author)
            {
                MessageBox.Show("Please select author",
                "Book must be added to author",
                MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.No);
            }
            else
            {
                BookWindow bookWindow = getBookWindow();
                bookWindow.AddButton.IsEnabled = true;
                bookWindow.CancelButton.IsEnabled = true;
                bookWindow.Author = author;
                bookWindow.ShowDialog();
            }
        }
        //Обробник натиснення на контекстне меню редагування студента
        private void MenuItemEditBook_Click(object sender, EventArgs e)
        {
            Author author = (Author)AuthorGrid.SelectedItem;
            Book book = (Book)BookGrid.SelectedItem;
            if (null == author)
            {
                MessageBox.Show("Please select book", "Nothing to edit",
                MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.No);
            }
            else
            {
                BookWindow bookWindow = getBookWindow();
                bookWindow.EditButton.IsEnabled = true;
                bookWindow.CancelButton.IsEnabled = true;
                bookWindow.Author = author;
                bookWindow.Book = book;
                bookWindow.InputTextBox1.Text = book.Title;
                bookWindow.InputTextBox2.Text = book.PublishingYear.ToString();
                bookWindow.InputTextBox3.Text = book.Language;
                bookWindow.InputTextBox4.Text = book.CountPages.ToString();
                bookWindow.ShowDialog();
            }
        }
        //Обробник натиснення на контекстне меню видалення студента
        private void MenuItemDeleteBook_Click(object sender, EventArgs e)
        {
            Book book = (Book)BookGrid.SelectedItem;
            if (null == book)
            {
                MessageBox.Show("Please select book", "Nothing to delete",
                MessageBoxButton.OK, MessageBoxImage.Information,
                MessageBoxResult.No);
            }
            else
            {
                book = getDaoFactory().getBookDAO()
                .GetById(book.Id);
                book.Author.BookList.Remove(book);
                getDaoFactory().getBookDAO().Delete(book);
                Author author = (Author)AuthorGrid.SelectedItem;
                IList<Book> bookList = getDaoFactory()
                .getBookDAO().getBooksByAuthor(book.Id);
                BookGrid.ItemsSource = bookList;
            }
        }
        //Обробник натиснення на рядок в таблиці групи
        private void DataGrid_Click(object sender, RoutedEventArgs e)
        {
            Author author = (Author)AuthorGrid.SelectedItem;
            if (null != author)
            {
                author = getDaoFactory().getAuthorDAO().GetById(author.Id);
                BookGrid.ItemsSource = author.BookList;
            }
        }
        //Обробник закриття головного вікна
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            getDaoFactory().destroy();
        }
    }
}