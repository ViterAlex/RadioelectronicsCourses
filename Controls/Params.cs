using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controls
{
    /// <summary>
    /// Параметры инструментов
    /// </summary>
    public class Params : IDisposable
    {
        /// <summary>
        /// Контур для закрашивания или обведения
        /// </summary>
        public GraphicsPath Path;
        /// <summary>
        /// Перо для обведения
        /// </summary>
        public Pen Pen;
        /// <summary>
        /// Кисть для закрашивания или стирания
        /// </summary>
        public Brush Brush;
        /// <summary>
        /// Область для стирания
        /// </summary>
        public Region EraseRegion;
        #region IDisposable

        public void Dispose()
        {
            Path?.Dispose();
            Pen?.Dispose();
            EraseRegion?.Dispose();
            Brush?.Dispose();
        }

        #endregion
    }
}