using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageMatching
{
    public class HSV
    {
        /// <summary>
        /// 色相（0～360）
        /// </summary>
        public float H { get; set; } = 0f;
        /// <summary>
        /// 彩度（0～1）
        /// </summary>
        public float S { get; set; } = 1f;
        /// <summary>
        /// 明度（0～1）
        /// </summary>
        public float V { get; set; } = 1f;

        public HSV() { }

        public HSV(float h, float s, float v)
        {
            H = h;
            S = s;
            V = v;
        }

        public void SetHSV(float h, float s, float v)
        {
            H = h;
            S = s;
            V = v;
        }

        public void SetColor(int r, int g, int b)
        {
            float max;
            float min;

            if (r > g && r > b)
            {
                //  ( { 緑の値 – 青の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60
                max = r;
                min = g < b ? g : b;
                H = ((g - b) / (max - min)) * 60f;
            }
            else if (g > r && g > b)
            {
                //  ( { 青の値 – 赤の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60 + 120
                max = g;
                min = r < b ? r : b;
                H = ((b - r) / (max - min)) * 60f + 120f;
            }
            else
            {
                // ( { 赤の値 – 緑の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60 + 240
                max = b;
                min = r < g ? r : g;
                H = ((r - g) / (max - min)) * 60f + 240f;
            }
            if (max == min)
            {
                H = 0f;
            }
            else
            {
                H = H < 0f ? H + 360f : H;
                H = H > 360f ? H - 360f : H;
            }
            S = max == 0 ? 0 : (max - min) / max;
            V = max / 255;
        }

        public static HSV FromHsv(float h, float s, float v)
        {
            return new HSV(h, s, v);
        }

        public static Color ToColor(HSV hsv)
        {
            return ToColor(hsv.H, hsv.S, hsv.V);
        }

        public static Color ToColor(float h, float s, float v)
        {
            float max = v * 255f;
            float min = (1f - s) * max;
            float r = 0f;
            float g = 0f;
            float b = 0f;
            h %= 360f;
            Action[] actions = {
                ()=> 
                {
                    // 0 <= h < 60
                    r = max;
                    g = (h / 60f) * (max - min) + min;
                    b = min;
                },
                ()=>
                {
                    // 60 <= h < 120
                    r = ((120f - h) / 60f) * (max - min) + min;
                    g = max;
                    b = min;
                },
                ()=>
                {
                    // 120 <= h < 180
                    r = min;
                    g = max;
                    b = ((h - 120f) / 60f) * (max - min) + min;
                },
                ()=>
                {
                    // 180 <= h < 240
                    r = min;
                    g = ((240f - h) / 60f) * (max - min) + min;
                    b = max;
                },
                ()=>
                {
                    // 240 <= h < 300
                    r = ((h - 240f) / 60f) * (max - min) + min;
                    g = min;
                    b = max;
                },
                ()=>
                {
                    // 300 <= h < 360
                    r = max;
                    g = min;
                    b = ((360f - h) / 60f) * (max - min) + min;
                }
            };

            actions[(int)(h / 60f)]();

            return Color.FromArgb((int)r, (int)g, (int)b);
        }

        public static HSV ToHSV(Color color)
        {
            return ToHSV(color.R, color.G, color.B);
        }

        public static HSV ToHSV(byte r, byte g, byte b)
        {
            return ToHSV((int)r, (int)g, (int)b);
        }

        public static HSV ToHSV(int r, int g, int b)
        {
            HSV hsv = new HSV();

            float max;
            float min;

            if (r > g && r > b)
            {
                //  ( { 緑の値 – 青の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60
                max = r;
                min = g < b ? g : b;
                hsv.H = ((g - b) / (max - min)) * 60f;
            }
            else if (g > r && g > b)
            {
                //  ( { 青の値 – 赤の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60 + 120
                max = g;
                min = r < b ? r : b;
                hsv.H = ((b - r) / (max - min)) * 60f + 120f;
            }
            else
            {
                // ( { 赤の値 – 緑の値 } / { RGBの中の最大値 – RGBの中の最小値 } ) × 60 + 240
                max = b;
                min = r < g ? r : g;
                hsv.H = ((r - g) / (max - min)) * 60f + 240f;
            }

            if (max == min)
            {
                hsv.H = 0f;
            }
            else
            {
                hsv.H = hsv.H < 0f ? hsv.H + 360f : hsv.H;
                hsv.H = hsv.H > 360f ? hsv.H - 360f : hsv.H;
            }
            hsv.S = max == 0 ? 0 : (max - min) / max;
            hsv.V = max / 255;

            return hsv;
        }
    }
}
