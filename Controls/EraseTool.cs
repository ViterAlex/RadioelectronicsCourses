using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;

namespace Controls
{
    /// <summary>
    /// Инструмент для стирания
    /// </summary>
    public class EraseTool : IDisposable
    {

        private RectangleF _eraseRect;
        private GraphicsPath _eraserPath;
        private Region _eraseRegion;
        private PointF _prevPoint;

        public EraseTool(float diameter, Color color)
        {
            EraseColor = color;
            _eraseRect = new RectangleF(new Point(), new SizeF(diameter, diameter));
        }
        /// <summary>
        /// Область, которую нужно стереть.
        /// </summary>
        public Region EraseRegion
        {
            get
            {
                return _eraseRegion.Clone();
            }
        }
        /// <summary>
        /// Цвет ластика
        /// </summary>
        public Color EraseColor { get; }

        /// <summary>
        /// Добавить точку стирания.
        /// </summary>
        public void AddErasePoint(PointF point)
        {
            _prevPoint = point;
            _eraseRect = _eraseRect.CenterTo(_prevPoint);

            if (_eraserPath == null)
                _eraserPath = new GraphicsPath();
            _eraserPath.AddEllipse(_eraseRect);

            if (_eraseRegion == null)
                _eraseRegion = new Region(_eraserPath);
            else
                _eraseRegion.Union(_eraserPath);

            _eraserPath.Reset();
        }

        /// <summary>
        /// Сброс ластика
        /// </summary>
        public void Reset()
        {
            _prevPoint = PointF.Empty;
            _eraserPath?.Dispose();
            _eraserPath = null;
            _eraseRegion?.Dispose();
            _eraseRegion = null;
        }
        /// <summary>
        /// Стирание области в объекте Graphics. Нужно для стирания во время движения мыши
        /// </summary>
        public void Erase(Graphics g)
        {
            g.FillRegion(EraseColor.Brush(), _eraseRegion);
        }

        #region IDisposable

        public void Dispose()
        {
            _eraserPath?.Dispose();
            _eraseRegion?.Dispose();
        }

        #endregion
    }
}
