using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Functional;

namespace Console
{
    class Program
    {
        const string path = @"c:\Users\Alexander.Goida\Downloads\image.jpg";
                
        static void Main(string[] args)
        {
            //var inputLine = System.Console.ReadLine();
            //if (string.IsNullOrWhiteSpace(inputLine) == false)
            {
                //var sequense = inputLine.Split(' ').Select(int.Parse).ToArray();
                var eng = new Engine();
                var seq = eng.Calc(new[]
                {
                    100, 150, 90, 45, 67, 44, 88, 65
                });
                eng.Draw(path, seq);
                eng.Show(path);
            }
        }
    }
}
