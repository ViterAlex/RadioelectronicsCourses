using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MeshAnalysis.Controls
{
    public partial class ColorSelectControl : UserControl
    {
        private const float PART = 2 / 3f;

        private readonly Size _defaultSize = new Size(44, 44);
        private readonly Size _defaultMinimumSize = new Size(24, 24);
        private readonly SolidBrush _fillBrush = (SolidBrush)Brushes.White;
        private readonly SolidBrush _strokeBrush = (SolidBrush)Brushes.Black;
        private readonly Cursor _defaultCursor = Cursors.Hand;

        private RectangleF FillRectangle
        {
            get
            {
                var h = Height * PART;
                var w = Width * PART;
                var rect = new RectangleF(Width - w, Height - h, w - 1, h - 1);
                rect.Inflate(-1, -1);
                return rect;
            }
        }

        private RectangleF StrokeRectangle
        {
            get
            {
                var h = Height * PART;
                var w = Width * PART;
                var rect = new RectangleF(0, 0, w - 1, h - 1);
                rect.Inflate(-1, -1);
                return rect;
            }
        }

        public ColorSelectControl()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint 
                | ControlStyles.DoubleBuffer
                | ControlStyles.OptimizedDoubleBuffer
                | ControlStyles.ResizeRedraw 
                | ControlStyles.UserPaint, true);

        }

        [Category("Appearance")]
        public Color FillColor
        {
            get
            {
                return _fillBrush.Color;
            }
            set
            {
                _fillBrush.Color = value;
                Invalidate();
                OnFillColorChanged();
            }
        }

        [Category("Appearance")]
        public Color StrokeColor
        {
            get
            {
                return _strokeBrush.Color;
            }
            set
            {
                _strokeBrush.Color = value;
                Invalidate();
                OnStrokeColorChanged();
            }
        }

        public event EventHandler FillColorChanged;
        public event EventHandler StrokeColorChanged;

        #region Overrides of UserControl

        protected override Size DefaultSize
        {
            get
            {
                return _defaultSize;
            }
        }

        #endregion

        #region Overrides of Control

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            OnResize(EventArgs.Empty);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var createParams = base.CreateParams;
                createParams.ExStyle |= 0x00000020; // WS_EX_TRANSPARENT
                return createParams;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            var w = Width * PART;
            var h = Height * PART;
            var reg = new Region(new RectangleF(0, 0, w, h));
            reg.Union(new RectangleF(Width - w, Height - h, w, h));
            Region = reg;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.FillRectangle(Brushes.Black, ClientRectangle);
            e.Graphics.FillRectangle(_fillBrush, FillRectangle);
            e.Graphics.FillRectangle(_strokeBrush, StrokeRectangle);
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            var index = -1;
            //В каком прямоугольнике кликнули
            if (StrokeRectangle.Contains(e.Location))
            {
                index = 1;
            }
            else if (FillRectangle.Contains(e.Location))
            {
                index = 0;
            }
            if (index == -1)
            {
                return;
            }
            using (var dialog = new ColorDialog())
            {
                dialog.Color = index == 0 ? FillColor : StrokeColor;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                switch (index)
                {
                    case 0:
                        FillColor = dialog.Color;
                        break;
                    case 1:
                        StrokeColor = dialog.Color;
                        break;
                }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            var tooltip = string.Empty;
            if (StrokeRectangle.Contains(e.Location))
            {
                tooltip = "Цвет контура";
            }
            else if (FillRectangle.Contains(e.Location))
            {
                tooltip = "Цвет заливки";
            }
            toolTip1.SetToolTip(this, tooltip);
        }

        protected override Cursor DefaultCursor
        {
            get
            {
                return _defaultCursor;
            }
        }

        protected override Size DefaultMinimumSize
        {
            get
            {
                return _defaultMinimumSize;
            }
        }

        #endregion

        protected virtual void OnFillColorChanged()
        {
            FillColorChanged?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnStrokeColorChanged()
        {
            StrokeColorChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
