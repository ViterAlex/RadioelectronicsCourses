using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace Controls
{
    /// <summary>
    /// ��������� ������������
    /// </summary>
    public class Params : IDisposable
    {
        /// <summary>
        /// ������ ��� ������������ ��� ���������
        /// </summary>
        public GraphicsPath Path;
        /// <summary>
        /// ���� ��� ���������
        /// </summary>
        public Pen Pen;
        /// <summary>
        /// ����� ��� ������������ ��� ��������
        /// </summary>
        public Brush Brush;
        /// <summary>
        /// ������� ��� ��������
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