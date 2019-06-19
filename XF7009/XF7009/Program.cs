using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7009
{
    class Student
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { if (!string.IsNullOrEmpty(value)) name = value; }
        }
        private int age;

        public int Age
        {
            get { return age; }
            set
            { if (value > 0) age = value; }
        }
        private int grade;

        public int Grade
        {
            get { return grade; }
            set { if (value > 0) grade = value; }
        }
        private string department;

        public string Department
        {
            get { return department; }
            set { if (!string.IsNullOrEmpty(value)) department = value; }
        }
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
