using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodAnalyserPro
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello welcome to Mood annalyser Problem");
            AnalyzeMood analyse = new AnalyzeMood("I am in Happy mood");
            analyse.AnalyseMood();
            Console.WriteLine("Mood is :" + analyse.AnalyseMood()); 
            Console.ReadLine();
        }
    }
}
