using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace Controls
{
    internal delegate void PaintMethod(Graphics g);

    public partial class SketchControl : UserControl
    {
        #region Свойства
        //Стэк повторения действий
        private readonly Stack<PaintMethod> _redo = new Stack<PaintMethod>();
        //Методы рисования
        private readonly List<PaintMethod> _actions = new List<PaintMethod>();

        private Point _endPoint;
        private Point _startPoint;
        private bool _isPressed;
        /// <summary>
        /// Ширина пера
        /// </summary>
        private float _penWidth;
        /// <summary>
        /// Тип фигуры: Окружность, Прямоугольник, Линия
        /// </summary>
        private ToolKind _tool;
        /// <summary>
        /// Равные стороны
        /// </summary>
        private static bool IsEqual => (ModifierKeys & Keys.Shift) != 0;
        /// <summary>
        /// Режим рисования: Только контур, Только заливка, Контур и заливка
        /// </summary>
        private ShapeFillMode _shapeFillMode;
        /// <summary>
        /// Цвет заливки
        /// </summary>
        private Color _fillColor;
        /// <summary>
        /// Цвет контура
        /// </summary>
        private Color _strokeColor;

        private EraseToolOld _eraseTool;
        /// <summary>
        /// Метод рисования при ведении мышью.
        /// </summary>
        private PaintMethod DragPaint
        {
            get
            {
                var param = GetParams(_fillColor.SemitransparentBrush(), _strokeColor.DashPen());
                return param == null ? null : GetPaintMethod(param);
            }
        }

        /// <summary>
        /// Тип фигуры: Окружность, Прямоугольник, Линия
        /// </summary>
        private ToolKind Tool
        {
            get
            {
                return _tool;
            }
            set
            {
                if (_tool == value) return;
                _tool = value;
                switch (_tool)
                {
                    case ToolKind.None:
                        toolsToolStrip.UncheckButtons();
                        break;
                    case ToolKind.Ellipse:
                    case ToolKind.Rectangle:
                    case ToolKind.Line:
                        break;
                    case ToolKind.Eraser:
                        if (_eraseTool == null)
                        {
                            _eraseTool = new EraseToolOld(10, sketchPanel.BackColor);
                        }
                        else
                        {
                            _eraseTool.Reset();
                        }
                        break;
                }
                sketchPanel.Cursor = _tool.GetAttribute<ToolAttribute>()?.ToolCursor;
            }
        }

        /// <summary>
        /// Режим заполнения фигуры: Только контур, Только заливка, Контур и заливка
        /// </summary>
        private ShapeFillMode ShapeFillMode
        {
            get
            {
                return _shapeFillMode;
            }
            set
            {
                if (_shapeFillMode == value)
                {
                    return;
                }
                _shapeFillMode = value;
                shapeFillModeButton.Image = _shapeFillMode.GetAttribute<ToolAttribute>()?.Image;
                shapeFillModeButton.Text = _shapeFillMode.GetAttribute<DescriptionAttribute>()?.Description;
                Invalidate(true);
            }
        }

        #endregion

        public SketchControl()
        {
            InitializeComponent();
            sketchPanel.SetDoubleBuffered();
            _shapeFillMode = ShapeFillMode.FillOnly;
            ShapeFillMode = ShapeFillMode.StrokeOnly;
            Load += (sender, args) =>
            {
                StartNewSketch();
                CreateButtons();
                AddToolstripItems();

                _fillColor = colorSelectControl1.Fill;
                _strokeColor = colorSelectControl1.Stroke;
                colorSelectControl1.FillColorChanged += (_, __) => _fillColor = colorSelectControl1.Fill;
                colorSelectControl1.StrokeColorChanged += (_, __) => _strokeColor = colorSelectControl1.Stroke;
            };
        }

        #region Обработчики событий
        private void clearButton_Click(object sender, EventArgs e)
        {
            StartNewSketch();
        }

        private void sketchPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            _isPressed = true;
            if (e.Button == MouseButtons.Right)
            {
                SwapColors();
            }
        }

        private void sketchPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPressed)
            {
                _endPoint = e.Location;
                _eraseTool?.AddErasePoint(e.Location);
                sketchPanel.Invalidate();
            }
        }

        private void sketchPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isPressed && _endPoint != Point.Empty)
            {
                if (Tool != ToolKind.Eraser)
                {
                    AddAction();
                }
                sketchPanel.Invalidate();
            }
            if (e.Button == MouseButtons.Right)
            {
                SwapColors();
            }
            if (Tool == ToolKind.Eraser)
            {
                _eraseTool.AddErasePoint(e.Location);
                AddAction();
                sketchPanel.Invalidate();
            }
            _eraseTool?.Reset();
            _isPressed = false;
            _endPoint = Point.Empty;
        }

        private void sketchPanel_Paint(object sender, PaintEventArgs e)
        {
            UpdateView();
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (PaintMethod pm in _actions)
                pm(e.Graphics);
            if (!_isPressed) return;
            switch (_tool)
            {
                case ToolKind.None:
                case ToolKind.Ellipse:
                case ToolKind.Rectangle:
                case ToolKind.Line:
                    DragPaint?.Invoke(e.Graphics);
                    break;
                case ToolKind.Eraser:
                    _eraseTool.Erase(e.Graphics);
                    break;
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            _redo.Push(_actions.Last());
            _actions.Remove(_actions.Last());
            Invalidate(true);
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            _actions.Add(_redo.Pop());
            Invalidate(true);
        }

        private void penWidthNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            _penWidth = (float)penWidthNumericUpDown.Value;
            Invalidate(true);
        }

        //Закрытие меню выбора режима заливки
        private void shapeFillModeButton_DropDownClosed(object sender, EventArgs e)
        {
            shapeFillModeButton.DropDownItems.Clear();
        }

        private void shapeFillModeButton_DropDownOpening(object sender, EventArgs e)
        {
            shapeFillModeButton.Image = _shapeFillMode.GetAttribute<ToolAttribute>()?.Image;
            foreach (ShapeFillMode value in Enum.GetValues(typeof(ShapeFillMode)))
            {
                var tsmi = new ToolStripMenuItem
                {
                    Text = value.GetAttribute<DescriptionAttribute>()?.Description,
                    Image = value.GetAttribute<ToolAttribute>()?.Image,
                    Checked = value == ShapeFillMode
                };
                tsmi.Click += (o, args) => ShapeFillMode = value;
                shapeFillModeButton.DropDownItems.Add(tsmi);
            }
            Invalidate(true);
        }

        private void shapeFillModeButton_ButtonClick(object sender, EventArgs e)
        {
            ShapeFillMode = ShapeFillMode.Switch();
        }
        #endregion

        #region Методы
        private void SwapColors()
        {
            var temp = _fillColor;
            _fillColor = _strokeColor;
            _strokeColor = temp;
        }

        private void UpdateView()
        {
            undoButton.Enabled = _actions.Count > 0;
            redoButton.Enabled = _redo.Count > 0;
        }

        /// <summary>
        /// Создаём кнопки для рисования фигур
        /// </summary>
        private void CreateButtons()
        {
            var type = typeof(ToolKind);
            //Возможные названия фигур
            var names = Enum.GetNames(type).Where(s => s != "None");

            foreach (var name in names)
            {
                //Фигура, соответствующая этой кнопке
                var value = (ToolKind)Enum.Parse(type, name);
                //Создаём кнопку
                var btn = new ToolStripButton
                {
                    Image = value.GetAttribute<ToolAttribute>()?.Image,
                    ImageAlign = ContentAlignment.MiddleLeft,
                    TextAlign = ContentAlignment.MiddleLeft,
                    CheckOnClick = true,
                    Checked = false,
                    Tag = value
                };
                btn.DisplayStyle = btn.Image == null ? ToolStripItemDisplayStyle.Text : ToolStripItemDisplayStyle.Image;
                //Клик по кнопке
                btn.Click += (sender, args) =>
                {
                    toolsToolStrip.UncheckButtons(btn);
                    if (!btn.Checked)
                    {
                        //Если кнопка отжата, то убираем фигуру
                        Tool = ToolKind.None;
                        return;
                    }
                    Tool = value;
                };
                //Текст кнопки получаем из атрибута Description
                btn.Text = value.GetAttribute<DescriptionAttribute>().Description;
                toolsToolStrip.Items.Add(btn);
            }
        }

        /// <summary>
        /// Перенос контролов из формы на панель инструментов
        /// </summary>
        private void AddToolstripItems()
        {
            //Добавляем на панель инструментов
            for (var i = flowLayoutPanel1.Controls.Count - 1; i >= 0; i--)
            {
                Control control = flowLayoutPanel1.Controls[i];
                if (control.Tag == null)
                {
                    continue;
                }
                toolStrip2.Items.Insert(int.Parse(control.Tag.ToString()), new ToolStripControlHost(control));
                //Удаляем из формы
                flowLayoutPanel1.Controls.Remove(control);
            }
            tableLayoutPanel1.Controls.Remove(flowLayoutPanel1);
            flowLayoutPanel1.Dispose();
            //Удаляем лишние строки из таблицы
            tableLayoutPanel1.RowStyles.RemoveAt(1);

        }

        /// <summary>Получить рисунок</summary>
        public Bitmap GetSketch()
        {
            var bmp = new Bitmap(sketchPanel.Width, sketchPanel.Height);
            sketchPanel.DrawToBitmap(bmp, sketchPanel.Bounds);
            return bmp;
        }

        /// <summary>
        /// Определение параметров рисуемой фигуры
        /// </summary>
        /// <param name="brush">Кисть для заливки</param>
        /// <param name="pen">Перо для контура</param>
        private Params GetParams(SolidBrush brush, Pen pen)
        {
            var @params = new Params
            {
                Path = new GraphicsPath(),
                Pen = pen.CloneTool(),
                Brush = brush.CloneTool(),
            };
            switch (Tool)
            {
                case ToolKind.Ellipse:
                    @params.Path.AddEllipse(_startPoint.GetRectangle(_endPoint, IsEqual));
                    break;
                case ToolKind.Rectangle:
                    @params.Path.AddRectangle(_startPoint.GetRectangle(_endPoint, IsEqual));
                    break;
                case ToolKind.Line:
                    @params.Path.AddLine(_startPoint, _endPoint);
                    @params.Brush.Dispose();
                    break;
                case ToolKind.Eraser:
                    @params.Brush = _eraseTool.EraseColor.Brush().CloneTool();
                    @params.Pen.Dispose();
                    @params.EraseRegion = _eraseTool.EraseRegion;
                    break;
                case ToolKind.None:
                    @params.Dispose();
                    @params = null;
                    break;
            }
            return @params;
        }

        /// <summary>
        /// Определение метода рисования по параметрам фигуры
        /// </summary>
        /// <param name="param">Параметры фигуры</param>
        private PaintMethod GetPaintMethod(Params param)
        {
            PaintMethod action = null;
            if (Tool == ToolKind.Line)
            {
                return g => g.DrawPath(param.Pen, param.Path);
            }
            else if (Tool == ToolKind.Eraser)
            {
                return g => g.FillRegion(param.Brush, param.EraseRegion);
            }
            switch (ShapeFillMode)
            {
                case ShapeFillMode.FillOnly:
                    action = g => g.FillPath(param.Brush, param.Path);
                    break;
                case ShapeFillMode.StrokeAndFill:
                    action = g =>
                    {
                        g.FillPath(param.Brush, param.Path);
                        g.DrawPath(param.Pen, param.Path);
                    };
                    break;
                case ShapeFillMode.StrokeOnly:
                    action = g => { g.DrawPath(param.Pen, param.Path); };
                    break;
            }
            return action;
        }

        /// <summary>
        /// Добавить метод рисования
        /// </summary>
        private void AddAction()
        {
            _redo.Clear();
            var param = GetParams(_fillColor.Brush(), _strokeColor.Pen(_penWidth));
            if (param == null)
            {
                return;
            }
            _actions.Add(GetPaintMethod(param));
        }

        /// <summary>
        /// Начать новый набросок
        /// </summary>
        public void StartNewSketch()
        {
            Tool = ToolKind.None;
            _actions.Clear();
            _redo.Clear();
            sketchPanel.Invalidate();
        }
        #endregion
    }
}