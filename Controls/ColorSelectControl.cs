using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Controls.Properties;

namespace Controls
{
    public partial class ColorSelectControl : UserControl
    {
        private const float PART = 2 / 3f;

        private readonly Size _defaultSize = new Size(48, 48);
        private readonly Size _defaultMinimumSize = new Size(24, 24);
        private Color _fill = Color.White;
        private Color _stroke = Color.Black;
        private readonly Cursor _defaultCursor = Cursors.Hand;

        private RectangleF FillRectangle
        {
            get
            {
                var h = Height * PART;
                var w = Width * PART;
                var rect = new RectangleF(Width - w, Height - h, w, h);
                return rect;
            }
        }

        private RectangleF StrokeRectangle
        {
            get
            {
                var h = Height * PART;
                var w = Width * PART;
                var rect = new RectangleF(0, 0, w, h);
                return rect;
            }
        }

        private RectangleF SwapImageRectangle
        {
            get
            {
                var x = StrokeRectangle.Right;
                var w = Width - StrokeRectangle.Width;
                var h = Height - FillRectangle.Height;
                return new RectangleF(x, 0, w, h);
            }
        }
        private static Image SwapImage
        {
            get
            {
                return Resources.SwapIcon;
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
        public Color Fill
        {
            get
            {
                return _fill;
            }
            set
            {
                _fill = value;
                Invalidate();
                OnFillColorChanged();
            }
        }

        [Category("Appearance")]
        public Color Stroke
        {
            get
            {
                return _stroke;
            }
            set
            {
                _stroke = value;
                Invalidate();
                OnStrokeColorChanged();
            }
        }

        public event EventHandler FillColorChanged;
        public event EventHandler StrokeColorChanged;

        #region Overrides
        protected override Size DefaultSize
        {
            get
            {
                return _defaultSize;
            }
        }

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
            var reg = new Region(StrokeRectangle);
            reg.Union(FillRectangle);
            reg.Union(SwapImageRectangle);
            Region = reg;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var rect = FillRectangle.RInflate(-1, -1);
            e.Graphics.FillRectangle(Brushes.White, rect);
            rect.Draw(e.Graphics, Pens.Black);
            e.Graphics.FillRectangle(Fill.Brush(), rect.RInflate(-2, -2));

            rect = StrokeRectangle.RInflate(-1, -1);
            e.Graphics.FillRectangle(Brushes.White, rect);
            rect.Draw(e.Graphics, Pens.Black);
            e.Graphics.FillRectangle(Stroke.Brush(), rect.RInflate(-2, -2));

            e.Graphics.DrawImage(SwapImage, SwapImageRectangle);
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
            else if (SwapImageRectangle.Contains(e.Location))
            {
                SwapColors();
                return;
            }
            if (index == -1)
            {
                return;
            }
            using (var dialog = new ColorDialog())
            {
                dialog.Color = index == 0 ? Fill : Stroke;
                dialog.SolidColorOnly = false;
                if (dialog.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                switch (index)
                {
                    case 0:
                        Fill = dialog.Color;
                        break;
                    case 1:
                        Stroke = dialog.Color;
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
            else if (SwapImageRectangle.Contains(e.Location))
            {
                tooltip = "Поменять цвета";
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

        private void SwapColors()
        {
            var temp = Fill;
            Fill = Stroke;
            Stroke = temp;
        }
    }
}
