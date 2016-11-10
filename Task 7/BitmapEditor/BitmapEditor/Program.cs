using System;
using System.Drawing;
using System.Windows.Forms;

namespace BitmapEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var bitmap = new Bitmap("avos.jpg");

            using (var imageEditor = new BitmapEditor(bitmap))
            {
                for (int x = 0; x < bitmap.Width / 2; x++)
                    for (int y = 0; y < bitmap.Height / 2; y++)
                        imageEditor.SetPixel(x, y, 0, 0, 0);

                var form = new Form();

                form.Width = imageEditor.Image.Width;
                form.Height = imageEditor.Image.Height;

                form.BackgroundImage = imageEditor.Image;

                Application.Run(form);
            }
        }
    }
}
