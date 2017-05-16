using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.Tools
{
    public class EraseTool : Tool
    {
        private Region _eraseRegion;

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
        /// Добавить точку стирания.
        /// </summary>
        private void UpdatePoints()
        {
            var _eraseRect = new RectangleF(0, 0, Radius, Radius).CenterTo(_points[_points.Count - 1]);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(_eraseRect);
                if (_eraseRegion == null)
                    _eraseRegion = new Region(gp);
                else
                    _eraseRegion.Union(gp);
            }
        }
        
        public override void MouseMove(MouseEventArgs e)
        {
            base.MouseMove(e);
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            _points.Add(e.Location);
            UpdatePoints();
        }

        public override void InteractivePaint(PaintEventArgs e)
        {
            base.InteractivePaint(e);
            e.Graphics.FillRegion(Fill, _eraseRegion);
        }

        public override Action<Graphics> GetAction()
        {
            return new Action<Graphics>(g => g.FillRegion(Fill.CloneTool(), EraseRegion));
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            _eraseRegion.Dispose();
            _eraseRegion = null;
        }
    }
}
