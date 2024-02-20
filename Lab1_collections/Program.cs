using System.Collections.Generic;
using System;

namespace ua.cn.stu
{
    class Program
    {
        private static IList<Student> studentList = new List<Student>();
        static void Main(string[] args)
        {
            for (; ; )
            {
                Console.WriteLine("Please enter command add, list or exit:");
                String command = Console.ReadLine();
                if (command == "add")
                {
                    Console.WriteLine("Please enter student name:");
                    String name = Console.ReadLine();
                    Console.WriteLine("Please enter student surname:");
                    String surname = Console.ReadLine();
                    Console.WriteLine("Please enter record book number:");
                    String recordBookNumber = Console.ReadLine();
                    Student student = new Student(name, surname, recordBookNumber);
                    studentList.Add(student);
                    Console.WriteLine("Student was successfully added to collection");
                }
                else if (command == "list")
                {
                    foreach (Student student in studentList)
                    {
                        Console.WriteLine("Student name -> " + student.getName() + ", Student surname -> " + student.getSurname() + ", Student recordbook number -> " + student.getRecordBookNumber());
                    }
                }
                else if (command == "exit")
                {
                    Console.WriteLine("Exiting the program.");
                    return;
                }
            }
        }
    }
}


