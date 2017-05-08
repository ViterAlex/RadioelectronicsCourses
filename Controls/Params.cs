using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controls
{
    /// <summary>
    /// Параметры фигуры
    /// </summary>
    public class Params : IDisposable
    {
        public GraphicsPath Path;
        public Pen Pen;
        public Brush Brush;

        #region IDisposable

        public void Dispose()
        {
            Path?.Dispose();
            Pen?.Dispose();
        }

        #endregion
    }
}