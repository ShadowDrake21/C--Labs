using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab2_task_work
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IList<Book> bookList = BookRepository.getInstance().GetAll();
            BookGrid.ItemsSource = bookList;
            Application.Current.MainWindow.Closing +=
            new CancelEventHandler(MainWindow_Closing);
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            Book book = (Book)BookGrid.SelectedItem;
            InputTextBox1.Text = book.Id.ToString();
            InputTextBox2.Text = book.Title;
            InputTextBox3.Text = book.Author;
            InputTextBox4.Text = book.Year.ToString();
            if (ComboBox1.Text == "+")
            {
                book.CanBeTakenHome = true;
            }
            else
            {
                book.CanBeTakenHome = false;
            }
            AddButton.IsEnabled = false;
            EditButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
        }
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            string messageBoxText = "Do you want to delete book?";
            string caption = "Delete book";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption,
            button, icon, MessageBoxResult.Yes);
            if (result.Equals(MessageBoxResult.OK))
            {
                Book book = (Book)BookGrid.SelectedItem;
                BookRepository.getInstance().Delete(book.Id);
                IList<Book> bookList = BookRepository.getInstance().GetAll();
                BookGrid.ItemsSource = bookList;
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = InputTextBox2.Text;
            book.Author = InputTextBox3.Text;
            book.Year = Int32.Parse(InputTextBox4.Text);
            if (ComboBox1.Text == "+")
            {
                book.CanBeTakenHome = true;
            }
            else
            {
                book.CanBeTakenHome = false;
            }
            BookRepository.getInstance().Save(book);
            IList<Book> bookList = BookRepository.getInstance().GetAll();
            BookGrid.ItemsSource = bookList;
            InputTextBox1.Text = "";
            InputTextBox2.Text = "";
            InputTextBox3.Text = "";
            ComboBox1.Text = "";
            InputTextBox4.Text = "";
            EditButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            AddButton.IsEnabled = true;
        }
        public void ButtonJSON_Click(object sender, EventArgs e)
        {
            BookRepository.getInstance().LoadFromJson("E:/3 year/2 semester/books_2.json");

            IList<Book> bookList = BookRepository.getInstance().GetAll();
            BookGrid.ItemsSource = bookList;

            FromJSON.IsEnabled = false;
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Id = Int64.Parse(InputTextBox1.Text);
            book.Title = InputTextBox2.Text;
            book.Author = InputTextBox3.Text;
            book.Year = Int32.Parse(InputTextBox4.Text);
            if (ComboBox1.Text == "+")
            {
                book.CanBeTakenHome = true;
            }
            else
            {
                book.CanBeTakenHome = false;
            }
            BookRepository.getInstance().Update(book);
            IList<Book> bookList = BookRepository.getInstance().GetAll();
            BookGrid.ItemsSource = bookList;
            InputTextBox1.Text = "";
            InputTextBox2.Text = "";
            InputTextBox3.Text = "";
            InputTextBox4.Text = "";
            ComboBox1.Text = "";
            EditButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            AddButton.IsEnabled = true;
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            InputTextBox1.Text = "";
            InputTextBox2.Text = "";
            InputTextBox3.Text = "";
            ComboBox1.Text = "";
            InputTextBox4.Text = "";
            EditButton.IsEnabled = false;
            CancelButton.IsEnabled = false;
            AddButton.IsEnabled = true;
        }
        void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            BookRepository.getInstance().Destroy();

        }
    }


}