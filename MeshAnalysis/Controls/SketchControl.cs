using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace MeshAnalysis.Controls
{
    public partial class SketchControl : UserControl
    {
        #region Свойства
        //Стэк повторения действий
        private readonly Stack<Action<Graphics>> _redo = new Stack<Action<Graphics>>();
        //Методы, которые будут рисовать фигуры
        private readonly List<Action<Graphics>> _actions = new List<Action<Graphics>>();

        private Point _endPoint;
        private Point _startPoint;
        private bool _isPressed;
        /// <summary>
        /// Тип фигуры: Окружность, Прямоугольник, Линия
        /// </summary>
        private FigureKind _figure;
        /// <summary>
        /// Равные стороны
        /// </summary>
        private static bool IsEqual => (ModifierKeys & Keys.Shift) != 0;
        /// <summary>
        /// Режим рисования: Только контур, Только заливка, Контур и заливка
        /// </summary>
        private DrawMode _drawMode;
        /// <summary>
        /// Цвет заливки
        /// </summary>
        private Color _fillColor;
        /// <summary>
        /// Цвет контура
        /// </summary>
        private Color _strokeColor;

        /// <summary>
        /// Метод рисования при ведении мышью.
        /// </summary>
        private Action<Graphics> DragPaint
        {
            get
            {
                var param = GetParams(_fillColor.SemitransparentBrush(), _strokeColor.DashPen());
                return param == null ? null : GetPaintMethod(param);
            }
        }
        #endregion

        public SketchControl()
        {
            InitializeComponent();
            sketchPanel.SetDoubleBuffered();
            Load += (sender, args) =>
            {
                StartNewSketch();
                CreateButtons();
                AddModeSelectorItems();
                AddToolstripItems();
                _fillColor = colorSelectControl1.FillColor;
                _strokeColor = colorSelectControl1.StrokeColor;
                colorSelectControl1.FillColorChanged += (_, __) => _fillColor = colorSelectControl1.FillColor;
                colorSelectControl1.StrokeColorChanged += (_, __) => _strokeColor = colorSelectControl1.StrokeColor;
            };

        }

        #region Обработчики событий
        private void modeSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            _drawMode = (DrawMode)modeSelector.SelectedIndex;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            StartNewSketch();
        }

        private void sketchPanel_MouseDown(object sender, MouseEventArgs e)
        {
            _startPoint = e.Location;
            _isPressed = true;
        }

        private void sketchPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isPressed)
            {
                _endPoint = e.Location;
                sketchPanel.Invalidate();
            }
        }

        private void sketchPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isPressed)
            {
                AddAction();
                sketchPanel.Invalidate();
            }
            _isPressed = false;
        }

        private void sketchPanel_Paint(object sender, PaintEventArgs e)
        {
            UpdateView();
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (Action<Graphics> ac in _actions)
                ac(e.Graphics);
            if (_isPressed)
                DragPaint?.Invoke(e.Graphics);
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

        #endregion

        #region Методы
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
            var type = typeof(FigureKind);
            //Возможные названия фигур
            var names = Enum.GetNames(type).Where(s => s != "None");

            foreach (var name in names)
            {
                //Создаём кнопку
                var btn = new ToolStripButton
                {
                    DisplayStyle = ToolStripItemDisplayStyle.Text,
                    TextAlign = ContentAlignment.MiddleLeft,
                    CheckOnClick = true,
                    Checked = false
                };
                //Фигура, соответствующая этой кнопке
                var value = (FigureKind)Enum.Parse(type, name);
                //Клик по кнопке
                btn.Click += (sender, args) =>
                {
                    UncheckButtons(btn);
                    if (!btn.Checked)
                    {
                        //Если кнопка отжата, то убираем фигуру
                        _figure = FigureKind.None;
                        return;
                    }
                    _figure = value;
                };
                //Текст кнопки получаем из атрибута Description
                btn.Text = value.GetAttributeOfType<DescriptionAttribute>().Description;
                figuresToolStrip.Items.Insert(0, btn);
            }
        }

        private void AddToolstripItems()
        {
            //Добавляем на панель инструментов
            toolStrip2.Items.Insert(0, new ToolStripControlHost(colorSelectControl1));
            toolStrip2.Items.Insert(2, new ToolStripControlHost(penWidthNumericUpDown));
            //Удаляем из формы
            flowLayoutPanel1.Controls.Remove(colorSelectControl1);
            flowLayoutPanel1.Controls.Remove(penWidthNumericUpDown);
            tableLayoutPanel1.Controls.Remove(flowLayoutPanel1);
            flowLayoutPanel1.Dispose();
            //Удаляем лишние строки.
            tableLayoutPanel1.RowStyles.RemoveAt(1);

        }

        private void AddModeSelectorItems()
        {
            var type = typeof(DrawMode);
            foreach (DrawMode value in Enum.GetValues(type))
            {
                modeSelector.Items.Add(value.GetAttributeOfType<DescriptionAttribute>().Description);
            }
            modeSelector.SelectedIndex = (int)_drawMode;
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
            var path = new GraphicsPath();
            switch (_figure)
            {
                case FigureKind.Ellipse:
                    path.AddEllipse(_startPoint.GetRectangle(_endPoint, IsEqual));
                    break;
                case FigureKind.Rectangle:
                    path.AddRectangle(_startPoint.GetRectangle(_endPoint, IsEqual));
                    break;
                case FigureKind.Line:
                    path.AddLine(_startPoint, _endPoint);
                    break;
                case FigureKind.None:
                    path.Dispose();
                    return null;
            }

            return new Params
            {
                Path = path,
                Pen = pen.CloneTool(),
                Brush = brush.CloneTool()
            };
        }

        /// <summary>
        /// Определение метода рисования по параметрам фигуры
        /// </summary>
        /// <param name="param">Параметры фигуры</param>
        /// <returns></returns>
        private Action<Graphics> GetPaintMethod(Params param)
        {
            Action<Graphics> action = g => { g.DrawPath(param.Pen, param.Path); };
            if (_figure == FigureKind.Line)
            {
                return action;
            }
            switch (_drawMode)
            {
                case DrawMode.FillOnly:
                    action = g => g.FillPath(param.Brush, param.Path);
                    break;
                case DrawMode.StrokeAndFill:
                    action = g =>
                    {
                        g.FillPath(param.Brush, param.Path);
                        g.DrawPath(param.Pen, param.Path);
                    };
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
            var param = GetParams(_fillColor.Brush(), _strokeColor.Pen((float)penWidthNumericUpDown.Value));
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
            _figure = FigureKind.None;
            _actions.Clear();
            sketchPanel.Invalidate();
        }

        /// <summary>
        /// Отжимание всех кнопок кроме заданной
        /// </summary>
        /// <param name="button">Кнопка, которую оставить нажатой</param>
        private static void UncheckButtons(ToolStripItem button)
        {
            var toolStripButtons = button
                .GetCurrentParent()
                .Items.OfType<ToolStripButton>()
                .Where(b => b.CheckOnClick && !b.Equals(button));
            foreach (var btn in toolStripButtons)
                btn.Checked = false;
        }
        #endregion
    }
}