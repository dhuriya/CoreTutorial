using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using CoreLearn.Models;

namespace CoreLearn.Models
{
    public class StudentRepository : IStudentRepository
    {
        //When need to log the Date and time into a text file 
        // using the constructor 
        public StudentRepository()
        {
            string filePath = @"K:\Deepu practice\CoreTutorial\CoreLearn\log.txt";
            string contentToWrite =$"StudentRepository Object Created: @{DateTime.Now.ToString()}";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(contentToWrite);
            }
        }
        public List<Student> DataSource()
        {
            return new List<Student>()
            {
                new Student() { StudentId = 101, Name = "James", Branch="CSE",Section ="A",Gender="Male"},
                new Student() { StudentId = 102, Name = "Smith", Branch="ETC",Section ="B",Gender="Male"},
                new Student() { StudentId = 103, Name = "David", Branch="CSE",Section ="A",Gender="Male"},
                new Student() { StudentId = 104, Name = "Sara", Branch="CSE",Section ="A",Gender="Female"},
                new Student() { StudentId = 105, Name = "Pam", Branch="ETC",Section ="B",Gender="Female"}
            };
        }
        public Student GetStudentById(int StudentId)
        {
            return DataSource().FirstOrDefault(x => x.StudentId == StudentId)?? new Student();
        } 
        public List<Student> GetAllStudents()
        {
            return DataSource();
        }
    }
}