using System.Drawing;
using System.Drawing.Imaging;

using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace ImageMatching
{
    public class MatConverter
    {
        static public Bitmap ChangeFormat(Bitmap src, PixelFormat format)
        {
            if (src.PixelFormat == format) return src;

            Bitmap bf = new Bitmap(src.Width, src.Height, format);
            using (Graphics g = Graphics.FromImage(bf))
            {
                g.DrawImageUnscaled(src, 0, 0);
            }
            return bf;
        }

        static public Bitmap ChangeFormat(Image src, PixelFormat format)
        {
            if (src.PixelFormat == format) return (Bitmap)src;

            return ChangeFormat((Bitmap)src, format);
        }

        static public Bitmap ToBitmap(Mat src)
        {
            return BitmapConverter.ToBitmap(src);
        }

        static public Bitmap ToBitmap(Mat src, PixelFormat format)
        {
            return ChangeFormat(BitmapConverter.ToBitmap(src), format);
        }

        static public Mat ToMat(Bitmap src, PixelFormat format)
        {
            var mat = ToMat(ChangeFormat(src, format));
            src.Dispose();
            src = null;
            return mat;
        }

        static public Mat ToMat(Image src, PixelFormat format)
        {
            var mat = ToMat(ChangeFormat(src, format));
            src.Dispose();
            src = null;
            return mat;
        }

        static public Mat ToMat(Bitmap src)
        {
            var mat = BitmapConverter.ToMat(src);
            src.Dispose();
            src = null;
            return mat;
        }

        static public Mat ToMat(Image src)
        {
            var mat = BitmapConverter.ToMat((Bitmap)src);
            src.Dispose();
            src = null;
            return mat;
        }
    }
}
