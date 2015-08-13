using System.Diagnostics;

namespace Functional.Good
{
    public class Engine
    {
        public int[] Calc(int[] inputSequence)
        {
            return inputSequence;
        }

        public void Draw(string pngPath, int[] sequence)
        {
            const int step = 10;
            using (Plotter plotter = new Plotter(pngPath))
            {
                int x = step;
                foreach (int item in sequence)
                {
                    plotter.DrawLine(x, 0, x, item);
                    x += step;
                }
            }
        }

        public void Show(string pngPath)
        {
            ProcessStartInfo psi = new ProcessStartInfo(pngPath)
            {
                UseShellExecute = true
            };
            Process.Start(psi);
        }
    }
}