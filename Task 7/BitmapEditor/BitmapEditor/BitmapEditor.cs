using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace BitmapEditor
{
    public class BitmapEditor : IDisposable
    {
        private struct Pixel
        {
            public byte[] Color { set; get; }

            public int X { set; get; }
            public int Y { set; get; }
        }

        public Bitmap Image { get; }
        private BitmapData imageData;

        private List<Pixel> modifiedPixels;

        private bool isDisposed = false;

        public BitmapEditor(Bitmap image)
        {
            this.Image = image;

            this.imageData = this.Image.LockBits(new Rectangle(0, 0, this.Image.Width, this.Image.Height),
                ImageLockMode.WriteOnly,
                this.Image.PixelFormat);

            this.modifiedPixels = new List<Pixel>();
        }

        public void SetPixel(int x, int y, byte R, byte G, byte B)
        {
            this.modifiedPixels.Add(new Pixel { Color = new byte[] { R, G, B }, X = x, Y = y });
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

            foreach (var pixel in this.modifiedPixels)
            {
                IntPtr ptr = this.imageData.Scan0;

                var pixelPosition = this.imageData.Stride / this.Image.Width * (pixel.Y * this.Image.Width + pixel.X);

                Marshal.Copy(pixel.Color,
                    0,
                    ptr + pixelPosition,
                    3);
            }

            this.Image.UnlockBits(this.imageData);

            this.Image.Save("new.jpg");

            this.Image.Dispose();
        }
    }
}
