using System;
using System.ComponentModel;
using System.Windows;
namespace Lab3_individual_task
{
  public partial class AuthorWindow : Window
  {
    private MainWindow parentWindow;
    public Author Author { get; set; }
    public AuthorWindow(MainWindow parentWindow)
    {
      this.parentWindow = parentWindow;
      this.Closing += new CancelEventHandler(Window_Closing);
      InitializeComponent();
    }
    public MainWindow getParentWindow()
    {
      return parentWindow;
    }
    //Обробник натиснення на кнопку додання групи
    private void ButtonAdd_Click(object sender, EventArgs e)
    {
      Author author = new Author();
      author.AuthorName = InputTextBox1.Text;
      author.BirthYear = Int32.Parse(InputTextBox2.Text);
      author.Country = InputTextBox3.Text;
      author.TheMostFamousBook = InputTextBox4.Text;
      getParentWindow().getDaoFactory()
      .getAuthorDAO().SaveOrUpdate(author);
      getParentWindow().AuthorGrid.ItemsSource = getParentWindow()
      .getDaoFactory().getAuthorDAO().GetAll();
      closeWindow();
    }

    private void ButtonEdit_Click(object sender, EventArgs e)
    {
      Author author = getParentWindow()
     .getDaoFactory().getAuthorDAO().GetById(Author.Id);
      author.AuthorName = InputTextBox1.Text;
      author.BirthYear = Int32.Parse(InputTextBox2.Text);
      author.Country = InputTextBox3.Text;
      author.TheMostFamousBook = InputTextBox4.Text;
      getParentWindow().getDaoFactory().getAuthorDAO()
      .SaveOrUpdate(author);
      getParentWindow().AuthorGrid.ItemsSource = getParentWindow()
      .getDaoFactory().getAuthorDAO().GetAll();
      closeWindow();
    }
    //Обробник натиснення на кнопку Cancel
    private void ButtonCancel_Click(object sender, EventArgs e)
    {
      closeWindow();
    }
    //Обробник закриття вікна групи
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