using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MeshAnalysis.Controls
{
    /// <summary>
    /// ��������� ������
    /// </summary>
    internal class Params : IDisposable
    {
        public GraphicsPath Path;
        public Pen Pen;

        #region IDisposable

        public void Dispose()
        {
            Path?.Dispose();
            Pen?.Dispose();
        }

        #endregion
    }
}