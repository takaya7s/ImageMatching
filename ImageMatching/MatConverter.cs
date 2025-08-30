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
            return ToMat(ChangeFormat(src, format));
        }

        static public Mat ToMat(Image src, PixelFormat format)
        {
            return ToMat(ChangeFormat(src, format));
        }

        static public Mat ToMat(Bitmap src)
        {
            return BitmapConverter.ToMat(src);
        }

        static public Mat ToMat(Image src)
        {
            return BitmapConverter.ToMat((Bitmap)src);
        }
    }
}
