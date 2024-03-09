using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
namespace Lab3_individual_task
{
  public partial class BookWindow : Window
  {
    private MainWindow parentWindow;
    public MainWindow getParentWindow()
    {
      return parentWindow;
    }
    public Author Author { get; set; }
    public Book Book { get; set; }
    public BookWindow(MainWindow parentWindow)
    {
      this.parentWindow = parentWindow;
      this.Closing += new CancelEventHandler(Window_Closing);
      InitializeComponent();
    }
    //Обробник натиснення на кнопку додання студента
    private void ButtonAdd_Click(object sender, EventArgs e)
    {
      Book book = new Book();
      book.Title = InputTextBox1.Text;
      book.PublishingYear = Int32.Parse(InputTextBox2.Text);
      book.Language = InputTextBox3.Text;
      book.CountPages = Int32.Parse(InputTextBox4.Text);
      Author author = getParentWindow()
      .getDaoFactory().getAuthorDAO().GetById(Author.Id);
      book.Author = author;
      author.BookList.Add(book);
      getParentWindow().getDaoFactory()
      .getBookDAO().SaveOrUpdate(book);
      IList<Book> bookList = getParentWindow()
      .getDaoFactory().getBookDAO()
      .getBooksByAuthor(author.Id);
      getParentWindow().BookGrid.ItemsSource = bookList;
      closeWindow();
    }
    //Обробник натиснення на кнопку редагування студента
    private void ButtonEdit_Click(object sender, EventArgs e)
    {
      Book book = getParentWindow()
       .getDaoFactory().getBookDAO().GetById(Book.Id);
      book.Title = InputTextBox1.Text;
      book.PublishingYear = Int32.Parse(InputTextBox2.Text);
      book.Language = InputTextBox3.Text;
      book.CountPages = Int32.Parse(InputTextBox4.Text);
      getParentWindow().getDaoFactory().getBookDAO()
      .SaveOrUpdate(book);
      getParentWindow().BookGrid.ItemsSource = getParentWindow()
      .getDaoFactory().getBookDAO()
      .getBooksByAuthor(Author.Id);
      closeWindow();
    }
    //Обробник натиснення на кнопку Cancel
    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      closeWindow();
    }
    //Обробник закриття вікна студента
    private void Window_Closing(object sender,
    System.ComponentModel.CancelEventArgs e)
    {
      e.Cancel = true;
      closeWindow();
    }
    private void closeWindow()
    {
      this.AddButton.IsEnabled = false;
      this.EditButton.IsEnabled = false;
      this.CancelButton.IsEnabled = false;
      this.InputTextBox1.Text = "";
      this.InputTextBox2.Text = "";
      this.InputTextBox3.Text = "";
      this.InputTextBox4.Text = "";
      this.Hide();
    }
  }
}