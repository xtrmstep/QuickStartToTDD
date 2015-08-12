using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace Functional
{
    internal class Plotter : IDisposable
    {
        private const int PLOT_SIZE = 800;
        private readonly string filePath;
        private Bitmap bmp;
        private bool isDisposed;

        public Plotter(string imagePath)
        {
            filePath = imagePath;
            bmp = new Bitmap(PLOT_SIZE, PLOT_SIZE);
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.FillRectangle(Brushes.White, 0, 0, PLOT_SIZE, PLOT_SIZE);
            }
        }

        public void Dispose()
        {
            if (!isDisposed)
            {
                using (MemoryStream memory = new MemoryStream())
                {
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        bmp.Save(memory, ImageFormat.Jpeg);
                        byte[] bytes = memory.ToArray();
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }

                bmp.Dispose();
                bmp = null;
                isDisposed = true;
            }
        }

        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            using (Graphics gr = Graphics.FromImage(bmp))
            {
                gr.DrawLine(Pens.Black, x1, y1, x2, y2);
            }
        }
    }
}