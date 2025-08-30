using System;
using System.Collections.Generic;

using OpenCvSharp;

namespace ImageMatching
{
    public class TemplateMatch
    {
        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲があるか検査します。<br></br>
        /// ※TemplateMatchModesの指定がないためCCoeffNormedとなります。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <returns></returns>
        static public bool IsMatch(Mat matSource, Mat matTarget, double holdLine)
        {
            return Match(matSource, matTarget, holdLine, TemplateMatchModes.CCoeffNormed).Width >= 0;
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲があるか検査します。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <param name="mode">TemplateMatchModes</param>
        /// <returns></returns>
        static public bool IsMatch(Mat matSource, Mat matTarget, double holdLine, TemplateMatchModes mode)
        {
            return Match(matSource, matTarget, holdLine, mode).Width >= 0;
        }

        /// <summary>
        /// 元の行列と探す行列を比較し類似度を取得します。<br></br>
        /// ※TemplateMatchModesの指定がないためCCoeffNormedとなります。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <returns>類似度</returns>
        static public double Match(Mat matSource, Mat matTarget)
        {
            Mat matBuffer = new Mat();

            // テンプレートマッチ
            Cv2.MatchTemplate(matSource, matTarget, matBuffer, TemplateMatchModes.CCoeffNormed);

            // 類似度が最大/最小となる画素の位置を調べる
            OpenCvSharp.Point minLocation, maxLocation;
            double minValue, maxValue;
            Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);
            matBuffer.Dispose();

            return maxValue;
        }

        /// <summary>
        /// 元の行列と探す行列を比較し類似度を取得します。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="mode">TemplateMatchModes</param>
        /// <returns>類似度</returns>
        static public double Match(Mat matSource, Mat matTarget, TemplateMatchModes mode)
        {
            Mat matBuffer = new Mat();

            // テンプレートマッチ
            Cv2.MatchTemplate(matSource, matTarget, matBuffer, mode);

            // 類似度が最大/最小となる画素の位置を調べる
            OpenCvSharp.Point minLocation, maxLocation;
            double minValue, maxValue;
            Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);
            matBuffer.Dispose();

            return maxValue;
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を取得します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は幅及び高さは-1を返します。<br></br>
        /// ※TemplateMatchModesの指定がないためCCoeffNormedとなります。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <returns></returns>
        static public Rect Match(Mat matSource, Mat matTarget, double holdLine)
        {
            return Match(matSource, matTarget, holdLine, TemplateMatchModes.CCoeffNormed);
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を取得します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は幅及び高さは-1を返します。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <param name="mode">TemplateMatchModes</param>
        /// <returns></returns>
        static public Rect Match(Mat matSource, Mat matTarget, double holdLine, TemplateMatchModes mode)
        {
            Mat matBuffer = new Mat();

            // テンプレートマッチ
            Cv2.MatchTemplate(matSource, matTarget, matBuffer, mode);

            // 類似度が最大/最小となる画素の位置を調べる
            OpenCvSharp.Point minLocation, maxLocation;
            double minValue, maxValue;
            Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);
            matBuffer.Dispose();

            // しきい値で判断
            if (maxValue >= holdLine)
            {
                //Console.WriteLine(maxValue);
                return new Rect(maxLocation.X, maxLocation.Y, matTarget.Width, matTarget.Height);
            }
            else
            {
                return new Rect(0, 0, -1, -1);
            }
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を取得します。<br></br>
        /// 複数見つかった場合はもっとも一致度の高い範囲を返します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は幅及び高さは-1を返します。<br></br>
        /// ※TemplateMatchModesの指定がないためCCoeffNormedとなります。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <returns></returns>
        static public Rect Match(Mat matSource, Mat[] matTargets, double holdLine)
        {
            return Match(matSource, matTargets, holdLine, TemplateMatchModes.CCoeffNormed);
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を取得します。<br></br>
        /// 複数見つかった場合はもっとも一致度の高い範囲を返します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は幅及び高さは-1を返します。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <param name="mode">TemplateMatchModes</param>
        /// <returns></returns>
        static public Rect Match(Mat matSource, Mat[] matTargets, double holdLine, TemplateMatchModes mode)
        {
            Rect rect = new Rect(0, 0, -1, -1);
            double max = holdLine;
            Mat matBuffer = new Mat();

            foreach (Mat mat in matTargets)
            {
                // テンプレートマッチ
                Cv2.MatchTemplate(matSource, mat, matBuffer, mode);

                // 類似度が最大/最小となる画素の位置を調べる
                OpenCvSharp.Point minLocation, maxLocation;
                double minValue, maxValue;
                Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);

                // しきい値で判断
                if (maxValue > max)
                {
                    max = maxValue;
                    rect = new Rect(maxLocation.X, maxLocation.Y, mat.Width, mat.Height);
                }
            }
            matBuffer.Dispose();

            return rect;
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を全て取得します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は空のリストを返します。<br></br>
        /// ※TemplateMatchModesの指定がないためCCoeffNormedとなります。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <returns></returns>
        static public List<Rect> Matches(Mat matSource, Mat matTarget, double holdLine)
        {
            return Matches(matSource, matTarget, holdLine, TemplateMatchModes.CCoeffNormed);
        }

        /// <summary>
        /// 元の行列と探す行列を比較し基準値を超える範囲を全て取得します。<br></br>
        /// 基準値を超える範囲が見つからなかった場合は空のリストを返します。
        /// </summary>
        /// <param name="matSource">元の行列</param>
        /// <param name="matTarget">探す行列</param>
        /// <param name="holdLine">マッチしたと判断する基準値（0.0～1.0）<br></br>
        /// 使用する場面によるが0.7～0.9くらいが妥当？</param>
        /// <param name="mode">TemplateMatchModes</param>
        /// <returns></returns>
        static public List<Rect> Matches(Mat matSource, Mat matTarget, double holdLine, TemplateMatchModes mode)
        {
            List<Rect> result = new List<Rect>();

            Mat matBuffer = new Mat();

            // テンプレートマッチ
            Cv2.MatchTemplate(matSource, matTarget, matBuffer, mode);

            // 類似度が最高・最低となる画素の位置とその類似度
            OpenCvSharp.Point minLocation, maxLocation;
            double minValue, maxValue;

            // 範囲を塗りつぶす色
            Scalar fillColor = new Scalar(0);

            while (true)
            {
                // 類似度が最大/最小となる画素の位置を調べる
                Cv2.MinMaxLoc(matBuffer, out minValue, out maxValue, out minLocation, out maxLocation);

                // しきい値で判断
                if (maxValue >= holdLine)
                {
                    // 範囲を登録
                    Rect rect = new Rect(maxLocation.X, maxLocation.Y, matTarget.Width, matTarget.Height);
                    result.Add(rect);

                    // 上記の範囲を塗りつぶす
                    Cv2.Rectangle(matBuffer, rect, fillColor);
                }
                else
                {
                    // 見つからない
                    break;
                }
            }
            matBuffer.Dispose();

            return result;
        }
    }
}
