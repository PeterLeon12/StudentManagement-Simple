using System;
using StudentManagement.Models;
using StudentManagement.Services;

namespace StudentManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            var catalog = new Catalog();

            string menu = "Choose an option:\n" +
                          "1. Display all students\n" +
                          "2. Display student by ID\n" +
                          "3. Add a new student\n" +
                          "4. Delete a student\n" +
                          "5. Update student details\n" +
                          "6. Update student address\n" +
                          "7. Add a grade to a student\n" +
                          "8. Calculate student general average\n" +
                          "9. Calculate subject-specific averages\n" +
                          "10. Exit\n";

            while (true)
            {
                Console.WriteLine(menu);
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        catalog.GetStudents();
                        break;
                    case "2":
                        Console.WriteLine("Enter student ID:");
                        int id = int.Parse(Console.ReadLine());
                        var student = catalog.GetStudentById(id);
                        if (student != null)
                        {
                            Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, City: {student.Address?.City}");
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Enter student details: ID, Name, Age");
                        int newId = int.Parse(Console.ReadLine());
                        string name = Console.ReadLine();
                        int age = int.Parse(Console.ReadLine());
                        catalog.AddStudent(new Student(newId, name, age));
                        break;
                    case "4":
                        Console.WriteLine("Enter student ID to delete:");
                        int deleteId = int.Parse(Console.ReadLine());
                        catalog.RemoveStudent(deleteId);
                        break;
                    case "5":
                        Console.WriteLine("Enter student ID, new Name, and new Age:");
                        int updateId = int.Parse(Console.ReadLine());
                        string newName = Console.ReadLine();
                        int newAge = int.Parse(Console.ReadLine());
                        catalog.UpdateStudent(updateId, newName, newAge);
                        break;
                    case "6":
                        Console.WriteLine("Enter student ID, City, Street, and Number:");
                        int addressId = int.Parse(Console.ReadLine());
                        string city = Console.ReadLine();
                        string street = Console.ReadLine();
                        string number = Console.ReadLine();
                        catalog.UpdateAddress(addressId, new Address(city, street, number));
                        break;
                    case "7":
                        Console.WriteLine("Enter student ID, grade (1-10), and subject:");
                        int markId = int.Parse(Console.ReadLine());
                        int grade = int.Parse(Console.ReadLine());
                        string subject = Console.ReadLine();
                        catalog.AddMark(markId, new Mark(grade, subject));
                        break;
                    case "8":
                        Console.WriteLine("Enter student ID to calculate average:");
                        int avgId = int.Parse(Console.ReadLine());
                        double average = catalog.GetStudentAverage(avgId);
                        Console.WriteLine($"Student's average: {average}");
                        break;
                    case "9":
                        Console.WriteLine("Enter student ID to calculate subject averages:");
                        int subjAvgId = int.Parse(Console.ReadLine());
                        var averages = catalog.GetSubjectAverages(subjAvgId);
                        if (averages != null)
                        {
                            foreach (var avg in averages)
                            {
                                Console.WriteLine($"Subject: {avg.Key}, Average: {avg.Value}");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Student not found!");
                        }
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
}
