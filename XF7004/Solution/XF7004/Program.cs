using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF7004
{
    class GradeSheetEventArgs : EventArgs
    {
        public string Name { get; set; }
        public double Score { get; set; }
    }
    class GradeSheet
    {
        public List<string> Items { get; set; } = new List<string>();
        public event EventHandler<GradeSheetEventArgs> AbnormalEventHandler;
        public void AddScore(string name, double score)
        {
            Items.Add($"{name} 得到分數 {score}");
            if(score<0 || score>100)
            {
                AbnormalEventHandler?.Invoke(this,
                    new GradeSheetEventArgs() { Name = name, Score = score });
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            GradeSheet gradeSheet = new GradeSheet();
            gradeSheet.AbnormalEventHandler += (s, e) =>
             {
                 Console.WriteLine($"    發現異常分數 {e.Name} / {e.Score}");
             };

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
