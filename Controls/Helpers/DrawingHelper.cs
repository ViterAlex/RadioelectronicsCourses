using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controls
{
    /// <summary>
    /// Методы расширений для работы с Drawing
    /// </summary>
    public static class DrawingHelper
    {
        private static readonly Pen _pen = new Pen(Color.Black);
        private static readonly SolidBrush _brush = new SolidBrush(Color.White);

        /// <summary>
        /// Сплошное перо определённого цвета
        /// </summary>
        /// <param name="color">Цвет пера</param>
        /// <param name="width">Ширина пера</param>
        public static Pen Pen(this Color color, float width = 1.0f)
        {
            _pen.Color = color;
            _pen.Width = width;
            _pen.DashStyle = DashStyle.Solid;
            return _pen;
        }

        /// <summary>
        /// Пунктирное перо определённого цвета
        /// </summary>
        /// <param name="color">Цвет пера</param>
        public static Pen DashPen(this Color color)
        {
            _pen.Color = color;
            _pen.Width = 2.0f;
            _pen.DashStyle = DashStyle.Dash;
            return _pen;
        }

        /// <summary>
        /// Кисть определённого цвета
        /// </summary>
        /// <param name="color">Цвет кисти</param>
        public static SolidBrush Brush(this Color color)
        {
            _brush.Color = color;
            return _brush;
        }

        /// <summary>
        /// Полупрозрачная кисть определённого цвета
        /// </summary>
        /// <param name="color">Цвет кисти</param>
        public static SolidBrush SemitransparentBrush(this Color color)
        {
            _brush.Color = Color.FromArgb(128, color);
            return _brush;
        }

        /// <summary>
        /// Клонирование инструмента
        /// </summary>
        public static T CloneTool<T>(this T tool) where T : ICloneable
        {
            return (T)tool.Clone();
        }
    }
}