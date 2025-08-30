using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatching
{
    public class RangeHSV
    {
        public float RangeH { get; set; } = 15f;
        public float RangeS { get; set; } = 0.05f;
        public float RangeV { get; set; } = 0.05f;
        /// <summary>
        /// CompareExにてS（彩度）がこの値以下になったらV（明度）のみで判定する
        /// </summary>
        public float VModeLine { get; set; } = 0.05f;

        public RangeHSV() { }

        public RangeHSV(float rangeH, float rangeS, float rangeV)
        {
            RangeH = rangeH;
            RangeS = rangeS;
            RangeV = rangeV;
        }

        public static float Mod(float left, float right)
        {
            float ret = left % right;
            ret = ret < 0 ? ret + right : ret;
            return ret;
        }

        public bool Compare(HSV hsv1, HSV hsv2)
        {
            bool result = true;

            float h = Math.Abs(hsv1.H - hsv2.H);
            result &= ((h < 180f ? h : 360f - h) <= RangeH);
            result &= (Math.Abs(hsv1.S - hsv2.S) <= RangeS);
            result &= (Math.Abs(hsv1.V - hsv2.V) <= RangeV);

            return result;
        }

        public bool Compare(HSV hsv1, Color color2)
        {
            return Compare(hsv1, HSV.ToHSV(color2));
        }

        public bool Compare(HSV hsv1, byte r2, byte g2, byte b2)
        {
            return Compare(hsv1, HSV.ToHSV(r2, g2, b2));
        }

        public bool Compare(Color color1, HSV hsv2)
        {
            return Compare(HSV.ToHSV(color1), hsv2);
        }

        public bool Compare(byte r1, byte g1, byte b1, HSV hsv2)
        {
            return Compare(HSV.ToHSV(r1, g1, b1), hsv2);
        }

        public bool Compare(Color color1, Color color2)
        {
            return Compare(HSV.ToHSV(color1), HSV.ToHSV(color2));
        }

        public bool Compare(byte r1, byte g1, byte b1, byte r2, byte g2, byte b2)
        {
            return Compare(HSV.ToHSV(r1, g1, b1), HSV.ToHSV(r2, g2, b2));
        }

        public bool CompareEx(HSV hsv1, HSV hsv2)
        {
            bool result = true;

            if (hsv1.S <= VModeLine && hsv2.S <= VModeLine)
            {
                result = (Math.Abs(hsv1.V - hsv2.V) <= RangeV);
            }
            else
            {
                float h = Math.Abs(hsv1.H - hsv2.H);
                result &= ((h < 180f ? h : 360f - h) <= RangeH);
                result &= (Math.Abs(hsv1.S - hsv2.S) <= RangeS);
                result &= (Math.Abs(hsv1.V - hsv2.V) <= RangeV);
            }

            return result;
        }

        public bool CompareEx(HSV hsv1, Color color2)
        {
            return CompareEx(hsv1, HSV.ToHSV(color2));
        }

        public bool CompareEx(HSV hsv1, byte r2, byte g2, byte b2)
        {
            return CompareEx(hsv1, HSV.ToHSV(r2, g2, b2));
        }

        public bool CompareEx(Color color1, HSV hsv2)
        {
            return CompareEx(HSV.ToHSV(color1), hsv2);
        }

        public bool CompareEx(byte r1, byte g1, byte b1, HSV hsv2)
        {
            return CompareEx(HSV.ToHSV(r1, g1, b1), hsv2);
        }

        public bool CompareEx(Color color1, Color color2)
        {
            return CompareEx(HSV.ToHSV(color1), HSV.ToHSV(color2));
        }

        public bool CompareEx(byte r1, byte g1, byte b1, byte r2, byte g2, byte b2)
        {
            return CompareEx(HSV.ToHSV(r1, g1, b1), HSV.ToHSV(r2, g2, b2));
        }
    }
}
