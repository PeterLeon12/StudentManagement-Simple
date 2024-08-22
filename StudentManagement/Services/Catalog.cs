using System;
using System.Collections.Generic;
using System.Linq;
using StudentManagement.Models;

namespace StudentManagement.Services
{
    public class Catalog
    {
        private List<Student> students = new List<Student>();

        public Catalog()
        {
            // Initialize with sample data
            InitializeData();
        }

        private void InitializeData()
        {
            students.Add(new Student(1, "John Doe", 20)
            {
                Address = new Address("New York", "5th Avenue", "101"),
                Marks = new List<Mark>
                {
                    new Mark(8, "Math"),
                    new Mark(7, "Science")
                }
            });

            students.Add(new Student(2, "Jane Smith", 22)
            {
                Address = new Address("Los Angeles", "Sunset Blvd", "55"),
                Marks = new List<Mark>
                {
                    new Mark(9, "History"),
                    new Mark(6, "Math")
                }
            });

            // Add more students similarly...
        }

        public void GetStudents()
        {
            foreach (var student in students)
            {
                Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, City: {student.Address?.City ?? "No Address"}");
            }
        }

        public Student GetStudentById(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void RemoveStudent(int id)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                students.Remove(student);
            }
        }

        public void UpdateStudent(int id, string name, int age)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                student.Name = name;
                student.Age = age;
            }
        }

        public void UpdateAddress(int id, Address newAddress)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                student.Address = newAddress;
            }
        }

        public void AddMark(int id, Mark mark)
        {
            var student = GetStudentById(id);
            if (student != null)
            {
                student.Marks.Add(mark);
            }
        }

        public double GetStudentAverage(int id)
        {
            var student = GetStudentById(id);
            return student?.Marks.Average(m => m.Value) ?? 0;
        }

        public Dictionary<string, double> GetSubjectAverages(int id)
        {
            var student = GetStudentById(id);
            return student?.Marks
                .GroupBy(m => m.Subject)
                .ToDictionary(g => g.Key, g => g.Average(m => m.Value));
        }
    }
}
