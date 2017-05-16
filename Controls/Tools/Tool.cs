using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls
{
    public abstract class Tool : IDisposable
    {
        public Tool()
        {

        }
        /// <summary>
        /// ������� ���������� ������ �����������
        /// </summary>
        public event EventHandler Done;
        /// <summary>
        /// ��� �����������
        /// </summary>
        public virtual ToolKind ToolKind { get; private set; }
        /// <summary>
        /// ���������� ����
        /// </summary>
        public virtual void MouseUp(MouseEventArgs e)
        {
            OnDone();
        }
        /// <summary>
        /// ������� ����
        /// </summary>
        public virtual void MouseDown(MouseEventArgs e) { }
        /// <summary>
        /// �������� ����
        /// </summary>
        public virtual void MouseMove(MouseEventArgs e) { }
        /// <summary>
        /// ���� �����
        /// </summary>
        /// <param name="e"></param>
        public virtual void MouseClick(MouseEventArgs e) { }
        /// <summary>
        /// ����� ��������� �� ����� ��������
        /// </summary>
        public virtual void InteractivePaint(PaintEventArgs e) { }
        /// <summary>
        /// ��������, ����������� ������������
        /// </summary>
        /// <returns></returns>
        public virtual Action<Graphics> GetAction() { return null; }

        /// <summary>
        /// �������, � ������� ���������� ������������
        /// </summary>
        public virtual Control Parent { get; set; }
        /// <summary>
        /// ����� �����������. ������ ��� �������.
        /// </summary>
        public virtual SolidBrush Fill { get; set; }
        /// <summary>
        /// ���� �����������. ������ ��� ������ ��������
        /// </summary>
        public virtual Pen Stroke { get; set; }
        /// <summary>
        /// ������ �����������. ��������, ������ �������.
        /// </summary>
        public virtual float Radius { get; set; }
        /// <summary>
        /// ����� �����������
        /// </summary>
        public Font Font { get; set; }
        /// <summary>
        /// �����, � �������� �������� ����������. ������ ��� ����������� �������� � ���� ������� ��-�������.
        /// </summary>
        protected List<Point> _points = new List<Point>();
        protected virtual void OnDone()
        {
            EventHandler temp = Done;
            if (temp != null)
            {
                temp(this, EventArgs.Empty);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    Fill?.Dispose();
                    Stroke?.Dispose();
                    Font?.Dispose();
                    foreach (var item in Done.GetInvocationList())
                    {
                        Done -= (EventHandler)item;
                    }
                }

                Fill = null;
                Stroke = null;
                Font = null;
                Done = null;
                _points = null;
                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }

}
