using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controls
{
    /// <summary>
    /// ������ ���������� ��� ������ � Drawing
    /// </summary>
    public static class DrawingHelper
    {
        private static readonly Pen _pen = new Pen(Color.Black);
        private static readonly SolidBrush _brush = new SolidBrush(Color.White);

        /// <summary>
        /// �������� ���� ������������ �����
        /// </summary>
        /// <param name="color">���� ����</param>
        /// <param name="width">������ ����</param>
        public static Pen Pen(this Color color, float width = 1.0f)
        {
            _pen.Color = color;
            _pen.Width = width;
            _pen.DashStyle = DashStyle.Solid;
            return _pen;
        }

        /// <summary>
        /// ���������� ���� ������������ �����
        /// </summary>
        /// <param name="color">���� ����</param>
        public static Pen DashPen(this Color color)
        {
            _pen.Color = color;
            _pen.Width = 2.0f;
            _pen.DashStyle = DashStyle.Dash;
            return _pen;
        }

        /// <summary>
        /// ����� ������������ �����
        /// </summary>
        /// <param name="color">���� �����</param>
        public static SolidBrush Brush(this Color color)
        {
            _brush.Color = color;
            return _brush;
        }

        /// <summary>
        /// �������������� ����� ������������ �����
        /// </summary>
        /// <param name="color">���� �����</param>
        public static SolidBrush SemitransparentBrush(this Color color)
        {
            _brush.Color = Color.FromArgb(128, color);
            return _brush;
        }

        /// <summary>
        /// ������������ �����������
        /// </summary>
        public static T CloneTool<T>(this T tool) where T : ICloneable
        {
            return (T)tool.Clone();
        }
    }
}