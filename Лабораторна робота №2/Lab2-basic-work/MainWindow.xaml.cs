using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Windows;

namespace Lab2_basic_work
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            IList<Student> studentList = StudentRepository.getInstance().GetAll();
            StudentGrid.ItemsSource = studentList;
            Application.Current.MainWindow.Closing +=
            new CancelEventHandler(MainWindow_Closing);
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            Student student = (Student)StudentGrid.SelectedItem;
            InputTextBox1.Text = student.Id.ToString();
            InputTextBox2.Text = student.FirstName;
            InputTextBox3.Text = student.LastName;
            ComboBox1.Text = student.Sex;
            InputTextBox4.Text = student.Age.ToString();
            AddButton.IsEnabled = false;
            EditButton.IsEnabled = true;
            CancelButton.IsEnabled = true;
        }
        private void MenuItemDelete_Click(object sender, EventArgs e)
        {
            string messageBoxText = "Do you want to delete student?";
            string caption = "Delete student";
            MessageBoxButton button = MessageBoxButton.OKCancel;
            MessageBoxImage icon = MessageBoxImage.Question;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption,
            button, icon, MessageBoxResult.Yes);
            if (result.Equals(MessageBoxResult.OK))
            {
                Student student = (Student)StudentGrid.SelectedItem;
                StudentRepository.getInstance().Delete(student.Id);
                IList<Student> studentList = StudentRepository.getInstance().GetAll();
                StudentGrid.ItemsSource = studentList;
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.FirstName = InputTextBox2.Text;
            student.LastName = InputTextBox3.Text;
            student.Sex = ComboBox1.Text;
            student.Age = Int32.Parse(InputTextBox4.Text);
            StudentRepository.getInstance().Save(student);
            IList<Student> studentList = StudentRepository.getInstance().GetAll();
            StudentGrid.ItemsSource = studentList;
        }
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.Id = Int64.Parse(InputTextBox1.Text);
            student.FirstName = InputTextBox2.Text;
            student.LastName = InputTextBox3.Text;
            student.Sex = ComboBox1.Text;
            student.Age = Int32.Parse(InputTextBox4.Text);
            StudentRepository.getInstance().Update(student);
            IList<Student> studentList = StudentRepository.getInstance().GetAll();
            StudentGrid.ItemsSource = studentList;
            InputTextBox1.Text = "";
            InputTextBox2.Text = "";
            InputTextBox3.Text = "";
            ComboBox1.Text = "";
            InputTextBox4.Text = "";
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
            StudentRepository.getInstance().Destroy();

        }
    }


}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
