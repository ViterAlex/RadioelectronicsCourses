using System;
using System.Drawing;

namespace Controls
{
    /// <summary>
    /// Методы расширений для структуры Rectangle(F)
    /// </summary>
    public static class RectangleHelper
    {
        /// <summary>
        /// Прямоугольник, заданные двумя точками диагонали
        /// </summary>
        /// <param name="firstPoint">Первая точка</param>
        /// <param name="secondPoint">Вторая точка</param>
        /// <param name="equal">Подгонять ли под квадрат</param>
        public static Rectangle GetRectangle(this Point firstPoint, Point secondPoint, bool equal = false)
        {
            if (equal)
            {
                //Если подгонять к квадрату, то ширину и высоту считаем по теореме пифагора
                PointF center = new PointF(
                    (firstPoint.X + secondPoint.X) / 2.0f, (firstPoint.Y + secondPoint.Y) / 2.0f);
                var rect = center.SquareFromCenter((float)(firstPoint.Distanse(secondPoint) / 2));
                return new Rectangle((int)rect.X, (int)rect.Y, (int)rect.Width, (int)rect.Height);
            }

            int x = Math.Min(firstPoint.X, secondPoint.X);
            int y = Math.Min(firstPoint.Y, secondPoint.Y);
            int width = Math.Abs(firstPoint.X - secondPoint.X) + 1;
            int height = Math.Abs(firstPoint.Y - secondPoint.Y) + 1;

            return new Rectangle(x, y, width, height);
        }

        public static RectangleF RInflate(this RectangleF rect, float dx, float dy)
        {
            rect.Inflate(dx, dy);
            return rect;
        }

        /// <summary>
        /// Рисование прямоугольника RectangleF
        /// </summary>
        public static void Draw(this RectangleF rect, Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <summary>
        /// Прямоугольник с центром в заданной точке
        /// </summary>
        public static RectangleF CenterTo(this RectangleF rect, PointF point)
        {
            var result = new RectangleF(point,new SizeF());
            result.Inflate(rect.Width,rect.Height);
            return result;
        }
        /// <summary>
        /// Расстояние между точками
        /// </summary>
        public static double Distanse(this Point start, Point end)
        {
            return Math.Sqrt(Math.Pow(end.X - start.X, 2) + Math.Pow(end.Y - start.Y, 2));
        }
        /// <summary>
        /// Квадрат по центральной точке
        /// </summary>
        public static RectangleF SquareFromCenter(this PointF point, float radius)
        {
            RectangleF ret = new RectangleF(point.X, point.Y, 0, 0);
            ret.Inflate(radius, radius);
            return ret;
        }
    }
}