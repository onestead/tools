using System;
using System.Collections.Generic;
using System.Drawing;

namespace Jp.Co.Onestead.Util
{
    public static class PointUtil
    {
        /// <summary>
        /// マイナス値を調整する
        /// </summary>
        /// <param name="points">座標集合</param>
        /// <returns>座標集合</returns>
        public static PointF[] Adjust(IEnumerable<PointF> points)
        {
            List<PointF> @return = new List<PointF>();
            float xAjs = 0f;
            float yAjs = 0f;
            foreach (PointF point in points)
            {
                if (point.X < 0f)
                    xAjs = Math.Abs(point.X);
                if (point.Y < 0f)
                    yAjs = Math.Abs(point.Y);
            }
            foreach (PointF point in points)
                @return.Add(new PointF(point.X + xAjs, point.Y + yAjs));
            return @return.ToArray();
        }

        /// <summary>
        /// 全座標が含まれる四角の4点座標を返却
        /// </summary>
        /// <param name="points">座標集合</param>
        /// <returns>4点座標『left-upper，right-upper，right-under，left-under』</returns>
        public static PointF[] MakeRect(IEnumerable<PointF> points)
        {
            PointF[] @return = new PointF[4];
            if (points == null)
                return @return;
            IEnumerator<PointF> iterator = points.GetEnumerator();
            if (iterator.MoveNext())
            {
                @return[0] = iterator.Current;
                @return[1] = iterator.Current;
                @return[2] = iterator.Current;
                @return[3] = iterator.Current;
                while (iterator.MoveNext())
                {
                    PointF point = iterator.Current;
                    if (@return[0].X > point.X)
                    {
                        @return[0].X = point.X;
                        @return[3].X = point.X;
                    }
                    if (@return[2].X < point.X)
                    {
                        @return[1].X = point.X;
                        @return[2].X = point.X;
                    }
                    if (@return[0].Y > point.Y)
                    {
                        @return[0].Y = point.Y;
                        @return[1].Y = point.Y;
                    }
                    if (@return[2].Y < point.Y)
                    {
                        @return[2].Y = point.Y;
                        @return[3].Y = point.Y;
                    }
                }
            }
            return Adjust(@return);
        }

        /// <summary>
        /// 全座標の中心座標を返却
        /// </summary>
        /// <param name="points">座標集合</param>
        /// <returns>中心座標</returns>
        public static PointF MakeCenter(IEnumerable<PointF> points)
        {
            PointF @return = PointF.Empty;
            PointF[] polygon = MakeRect(points);
            @return.X = Math.Abs(polygon[0].X + polygon[2].X) / 2;
            @return.Y = Math.Abs(polygon[0].Y + polygon[2].Y) / 2;
            return @return;
        }

        /// <summary>
        /// 直線A(A1-A2)と直性B(B1-B2)が交差する場合はTRUEを返却
        /// </summary>
        /// <param name="result">直線A(A1-A2)と直性B(B1-B2)が交差する点の座標</param>
        /// <param name="a">座標A1</param>
        /// <param name="b">座標A2</param>
        /// <param name="p">座標B1</param>
        /// <param name="q">座標B2</param>
        /// <returns>交差有無</returns>
        public static bool MakeIntersection(out PointF result, PointF a, PointF b, PointF p, PointF q)
        {
            //交点X,Y
            //3.二直線の交点(https://www.google.co.jp/webhp?sourceid=chrome-instant&ion=1&espv=2&ie=UTF-8#q=PDF%2F3DMath+pdf)
            result = PointF.Empty;
            double d = (b.X - a.X) * (q.Y - p.Y) - (b.Y - a.Y) * (q.X - p.X);
            if (d == 0d)
                return false;
            double n1 = (a.Y - p.Y) * (q.X - p.X) - (a.X - p.X) * (q.Y - p.Y);
            double s1 = n1 / d;
            double n2 = (a.Y - p.Y) * (b.X - a.X) - (a.X - p.X) * (b.Y - a.Y);
            double s2 = n2 / d;
            if (s1 < 0d || s1 > 1d || s2 < 0d || s2 > 1d)
                return false;
            result.X = (float)(a.X + (s1 * (b.X - a.X)));
            result.Y = (float)(a.Y + (s1 * (b.Y - a.Y)));
            return true;
        }

        /// <summary>
        /// 頂点数が偶数な正多角形の座標を返却
        /// </summary>
        /// <param name="vertexNumber">頂点数</param>
        /// <returns>座標</returns>
        public static PointF[] MakeRegPoligon(byte vertexNumber)
        {
            double radian = 360 / vertexNumber;
            double theta = 2 * Math.PI * radian / 360;
            if ((vertexNumber & 1) == 1)
                return MakeRegPoligon(vertexNumber, theta, 0.5f, 0.5f, 0.5f);
            PointF[] points = new PointF[vertexNumber];
            for (int i = 0; i < vertexNumber; i++)
                points[i] = new PointF(1f - (float)Math.Cos(theta * i), 1f - (float)Math.Sin(theta * i));
            return points;
        }

        /// <summary>
        /// 頂点数が奇数な正多角形座標を返却
        /// </summary>
        /// <param name="vertexNumber">頂点数</param>
        /// <param name="theta">中心角</param>
        /// <param name="x">1点目のX座標</param>
        /// <param name="y">1点目のY座標</param>
        /// <param name="radius">外周の半径</param>
        /// <returns>座標</returns>
        public static PointF[] MakeRegPoligon(byte vertexNumber, double theta, double x, double y, float radius)
        {
            PointF[] points = new PointF[vertexNumber];
            points[0] = new PointF((float)x, (float)(y - radius));
            int half = vertexNumber >> 1;
            for (int i = 1, k = 1; i < vertexNumber; i++)
            {
                if (i <= half)
                {
                    points[i] = new PointF(
                        (float)(x + radius * Math.Sin(k * theta)),
                        (float)(y - radius * Math.Cos(k * theta))
                    );
                    k++;
                }
                else
                {
                    k--;
                    points[i] = new PointF(
                        (float)(x - radius * Math.Sin(k * theta)),
                        (float)(y - radius * Math.Cos(k * theta))
                    );
                }
            }
            return points;
        }
    }
}
