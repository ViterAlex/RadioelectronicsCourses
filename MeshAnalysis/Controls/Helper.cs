using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Reflection;
using System.Windows.Forms;

namespace MeshAnalysis.Controls
{
    public static class Helper
    {
        private static readonly Pen _pen = new Pen(Color.Black);

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
        /// Прямоугольник, заданные двумя точками диагонали
        /// </summary>
        /// <param name="firstPoint">Первая точка</param>
        /// <param name="secondPoint">Вторая точка</param>
        /// <param name="equal">Подгонять ли под квадрат</param>
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

        /// <summary>
        /// Включение двойной буферизации для контрола
        /// </summary>
        public static void SetDoubleBuffered(this Control control)
        {
            PropertyInfo aProp =
                typeof(System.Windows.Forms.Control).GetProperty(
                    "DoubleBuffered",
                    BindingFlags.NonPublic |
                    BindingFlags.Instance);

            aProp?.SetValue(control, true, null);
        }

        /// <summary>
        /// Gets an attribute on an enum field value
        /// </summary>
        /// <typeparam name="T">The type of the attribute you want to retrieve</typeparam>
        /// <param name="enumVal">The enum value</param>
        /// <returns>The attribute of type T that exists on the enum value</returns>
        public static T GetAttributeOfType<T>(this Enum enumVal) where T : System.Attribute
        {
            var type = enumVal.GetType();
            var memInfo = type.GetMember(enumVal.ToString());
            var attributes = memInfo[0].GetCustomAttributes(typeof(T), false);
            return attributes.Length > 0 ? (T)attributes[0] : null;
        }
    }
}
