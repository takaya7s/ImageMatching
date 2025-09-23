using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OpenCvSharp;

using ImageMatching;

namespace TestImageMatching
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pbSrc_Click(object sender, EventArgs e)
        {
            var ev = (MouseEventArgs)e;
            if (ev.Button == MouseButtons.Left)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pbSrc.Image = Image.FromFile(ofd.FileName);
                }
            }
            else if (ev.Button == MouseButtons.Right)
            {
                if (pbSrc.Image != null)
                {
                    Mat mat = MatConverter.ToMat(pbSrc.Image, PixelFormat.Format24bppRgb);
                    Cv2.ImShow("Form1", mat);
                    mat.Dispose();
                }
            }
        }

        private void pbTarget_Click(object sender, EventArgs e)
        {
            var ev = (MouseEventArgs)e;
            if (ev.Button == MouseButtons.Left)
            {
                OpenFileDialog ofd = new OpenFileDialog();
                DialogResult dr = ofd.ShowDialog();
                if (dr == DialogResult.OK)
                {
                    pbTarget.Image = Image.FromFile(ofd.FileName);
                }
            } else if (ev.Button == MouseButtons.Right)
            {
                if (pbTarget.Image != null)
                {
                    Mat mat = MatConverter.ToMat(pbTarget.Image, PixelFormat.Format24bppRgb);
                    Cv2.ImShow("Form1", mat);
                    mat.Dispose();
                }
            }
        }

        private void btnTMOne_Click(object sender, EventArgs e)
        {
            Mat matSource = MatConverter.ToMat(pbSrc.Image, PixelFormat.Format24bppRgb);
            Mat matTarget = MatConverter.ToMat(pbTarget.Image, PixelFormat.Format24bppRgb);

            // しきい値
            double holdLine = double.Parse(textBox1.Text);

            // テンプレートマッチ
            Rect rect = TemplateMatch.Match(matSource, matTarget, holdLine);

            Console.WriteLine("xy: " + rect.Left + ", " + rect.Top);
            Console.WriteLine("wh: " + rect.Width + ", " + rect.Height);

            if (rect.Width < 0)
            {
                // 見つからない
                MessageBox.Show("見つかりませんでした");
            }
            else
            {
                // 最も類似度が高い場所に赤枠を表示
                Cv2.Rectangle(matSource, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

                // ウィンドウに画像を表示
                Cv2.ImShow("Form1", matSource);
            }

            matSource.Dispose();
            matTarget.Dispose();
        }

        private void btnTMSome_Click(object sender, EventArgs e)
        {
            Mat matSource = MatConverter.ToMat(pbSrc.Image, PixelFormat.Format24bppRgb);
            Mat matTarget = MatConverter.ToMat(pbTarget.Image, PixelFormat.Format24bppRgb);

            // しきい値
            var holdLine = double.Parse(textBox1.Text);

            // テンプレートマッチ
            List<Rect> rects = TemplateMatch.Matches(matSource, matTarget, holdLine);

            foreach (Rect rect in rects)
            {
                // しきい値を超えてる場所に赤枠を表示
                Cv2.Rectangle(matSource, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);
            }

            // ウィンドウに画像を表示
            Cv2.ImShow("Form1", matSource);

            matSource.Dispose();
            matTarget.Dispose();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Mat matSource = MatConverter.ToMat(pbSrc.Image, PixelFormat.Format24bppRgb);
            Mat matTarget = MatConverter.ToMat(pbTarget.Image, PixelFormat.Format24bppRgb);
            Mat matBuffer = new Mat();

            // テンプレートマッチ
            Cv2.MatchTemplate(matSource, matTarget, matBuffer, TemplateMatchModes.CCoeffNormed);

            // 類似度が最大/最小となる画素の位置を調べる
            OpenCvSharp.Point minLocation, maxLocation;
            double minValue, maxValue;
            Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);

            // しきい値で判断
            var holdLine = double.Parse(textBox1.Text);
            // 最も類似度が低い場所に赤枠を表示
            Rect rect = new Rect(minLocation.X, minLocation.Y, matTarget.Width, matTarget.Height);
            Cv2.Rectangle(matSource, rect, new OpenCvSharp.Scalar(0, 0, 255), 2);

            // ウィンドウに画像を表示
            Cv2.ImShow("Form1", matSource);

            matSource.Dispose();
            matTarget.Dispose();
            matBuffer.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            test04();
        }

        private void test()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is called.");



            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is finished.");
        }

        private static float mod(float left, float right)
        {
            float ret = left % right;
            ret = ret < 0 ? ret + right : ret;
            return ret;
        }

        private void test04()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is called.");

            Color color;
            HSV hsv;

            color = Color.FromArgb(229, 88, 104);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(240, 208, 28);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(26, 40, 62);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(242, 210, 26);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(246, 228, 12);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(160, 160, 160);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(76, 64, 64);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(226, 92, 232);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(232, 200, 18);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            color = Color.FromArgb(0, 0, 0);
            hsv = HSV.ToHSV(color);
            Console.WriteLine("{0:0}f, {1:0.00}f, {2:0.00}f", hsv.H, hsv.S, hsv.V);

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is finished.");
        }

        private void test03()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is called.");

            RangeHSV range = new RangeHSV();

            HSV hsv1 = new HSV(30f, 0.8f, 0.9f);
            HSV hsv2 = new HSV(15.08f, 0.751f, 0.9498f);
            Console.WriteLine(range.Compare(hsv1, hsv2));   // True
            Console.WriteLine(range.Compare(hsv2, hsv1));   // True

            hsv1 = new HSV(60f, 1f, 1f);
            hsv2 = new HSV(45.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(44.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False
            hsv2 = new HSV(74.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(75.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False

            hsv1 = new HSV(5f, 1f, 1f);
            hsv2 = new HSV(350.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(349.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False
            hsv2 = new HSV(19.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(20.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False

            hsv1 = new HSV(355f, 1f, 1f);
            hsv2 = new HSV(340.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(339.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False
            hsv2 = new HSV(9.9f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // True
            hsv2 = new HSV(10.1f, 1f, 1f);
            Console.WriteLine("{0} nearly {1} ? {2}", hsv1.H, hsv2.H, range.Compare(hsv1, hsv2));   // False

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is finished.");
        }

        private void test02()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is called.");

            float h = 30f;
            float s = 0.25f;
            float v = 1f;
            HSV hsv = new HSV(h, s, v);
            Console.WriteLine("H = {0}, S = {1}, V = {2}", hsv.H, hsv.S, hsv.V);

            Color color = HSV.ToColor(hsv);
            Console.WriteLine("R = {0}, G = {1}, B = {2}", color.R, color.G, color.B);

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is finished.");
        }

        private void test01()
        {
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is called.");

            int r = 133;
            int g = 205;
            int b = 75;
            Color color = Color.FromArgb(r, g, b);
            Console.WriteLine("R = {0}, G = {1}, B = {2}", color.R, color.G, color.B);

            HSV hsv = HSV.ToHSV(color);
            Console.WriteLine("H = {0}, S = {1}, V = {2}", hsv.H, hsv.S, hsv.V);

            color = HSV.ToColor(hsv);
            Console.WriteLine("R = {0}, G = {1}, B = {2}", color.R, color.G, color.B);

            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name + "() is finished.");
        }
    }
}
