using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7008
{
    class Student
    {
        string name;
        int age;
        int grade;
        string department;
        public void Display()
        {
            Console.WriteLine($"{name}/{age}/{grade}/{department}");
        }
        public void Init(string name, int age, int grade, string department)
        {
            this.name = name;
            this.age = age;
            this.grade = grade;
            this.department = department;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Init("Vulcan", 19, 2, "CS");
            student.Display();

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
