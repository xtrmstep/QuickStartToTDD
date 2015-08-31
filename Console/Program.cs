using System.IO;
using Functional.Bad;

namespace Console
{
    internal class Program
    {
        private static void Main()
        {
            //string path = Path.GetTempPath() + "image.jpg";

            //Engine eng = new Engine();
            //int[] seq = eng.Calc(new[]
            //{
            //    200, 250, 190, 145, 167, -44, 188, 165
            //});
            //eng.Draw(path, seq);

            var result = MathFunc.Add(
                MathFunc.Div(4, 
                MathFunc.Subtract(6, 
                MathFunc.Subtract(10, 4))), 
                MathFunc.Mul(3, 
                MathFunc.Subtract(7, 4)));

            System.Console.WriteLine(result);
            System.Console.ReadKey();

        }
    }
}