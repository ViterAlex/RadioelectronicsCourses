using System;
using System.Drawing;

namespace Controls
{
    /// <summary>
    /// ������ ���������� ��� ��������� Rectangle(F)
    /// </summary>
    public static class RectangleHelper
    {
        /// <summary>
        /// �������������, �������� ����� ������� ���������
        /// </summary>
        /// <param name="firstPoint">������ �����</param>
        /// <param name="secondPoint">������ �����</param>
        /// <param name="equal">��������� �� ��� �������</param>
        public static Rectangle GetRectangle(this Point firstPoint, Point secondPoint, bool equal = false)
        {
            var w = Math.Abs(firstPoint.X - secondPoint.X);
            var h = Math.Abs(firstPoint.Y - secondPoint.Y);
            var pt = new Point
            {
                X = secondPoint.X < firstPoint.X ? secondPoint.X : firstPoint.X,
                Y = secondPoint.Y < firstPoint.Y ? secondPoint.Y : firstPoint.Y
            };
            if (equal)
            {
                h = w;
            }
            return new Rectangle(pt, new Size(w, h));
        }

        public static RectangleF RInflate(this RectangleF rect, float dx, float dy)
        {
            rect.Inflate(dx, dy);
            return rect;
        }

        /// <summary>
        /// ��������� �������������� RectangleF
        /// </summary>
        public static void Draw(this RectangleF rect, Graphics g, Pen pen)
        {
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        /// <summary>
        /// ������������� � ������� � �������� �����
        /// </summary>
        public static RectangleF CenterTo(this RectangleF rect, PointF point)
        {
            return new RectangleF(new PointF(point.X - rect.Width / 2, point.Y - rect.Height / 2), rect.Size);
        }
    }
}