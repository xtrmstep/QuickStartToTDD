using System.IO;
using Functional.Bad;

namespace Console
{
    internal class Program
    {
        private static void Main()
        {
            string path = Path.GetTempPath() + "image.jpg";

            Engine eng = new Engine();
            int[] seq = eng.Calc(new[]
            {
                200, 250, 190, 145, 167, -44, 188, 165
            });
            eng.Draw(path, seq);
        }
    }
}