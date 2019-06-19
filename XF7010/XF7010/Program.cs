using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7010
{
    class Student
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }
        public string Department { get; set; }
        public Student(string name, int age,
            int grade, string department)
        {
            Name = name;
            Age = age;
            Grade = grade;
            Department = department;
        }
        public void Display()
        {
            Console.WriteLine($"{Name}/{Age}/" +
                $"{Grade}/{Department}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student("Vulcan", 19, 2, "CS");
            student.Display();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
