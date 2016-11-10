using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BitmapEditor
{
    public class BitmapEditor : IDisposable
    {
        private bool isDisposed = false;
        public Bitmap Image { get; }

        public BitmapEditor(Bitmap image)
        {
            this.Image = image;
        }

        public void SetPixel(int x, int y, byte R, byte G, byte B)
        {
            var lockableBox = new Rectangle(x, y, 1, 1);

            var imageDate = this.Image.LockBits(lockableBox, ImageLockMode.ReadWrite, this.Image.PixelFormat);

            IntPtr ptr = imageDate.Scan0;

            byte[] pixelColor = new byte[3];

            Marshal.Copy(ptr, pixelColor, 0, 3);

            pixelColor[0] = R;
            pixelColor[1] = G;
            pixelColor[2] = B;

            Marshal.Copy(pixelColor, 0, ptr, 3);

            this.Image.UnlockBits(imageDate);
        }

        ~BitmapEditor()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            this.isDisposed = true;

            this.Image.Dispose();
        }
    }
}
