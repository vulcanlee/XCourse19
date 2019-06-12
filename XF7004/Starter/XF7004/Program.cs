using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7004
{
    class GradeSheet
    {
        public List<string> Items { get; set; } = new List<string>();
        public void AddScore(string name, double score)
        {
            Items.Add($"{name} 得到分數 {score}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GradeSheet gradeSheet = new GradeSheet();

            Random random = new Random();
            for (int i = 0; i < 100; i++)
            {
                gradeSheet.AddScore($"Name{i}", random.Next(-3,110));
            }

            Console.WriteLine("Press any key for continuing...");
            Console.ReadKey();
        }
    }
}
