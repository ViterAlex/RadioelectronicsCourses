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

        private readonly List<Action<Graphics>> _actions = new List<Action<Graphics>>();
        private Color _currentColor = Color.Black;
        private Color _dragColor = Color.DarkGray;
        private Point _endPoint;
        private Point _startPoint;
        private bool _isPressed;
        //Методы, которые будут рисовать фигуры
        private Action<Graphics> _dragPaint;
        //Тип фигуры
        private FigureKind _figure;
        /// <summary>
        /// Равные стороны
        /// </summary>
        private static bool IsEqual => (ModifierKeys & Keys.Shift) != 0;

        /// <summary>
        /// Метод рисования при ведении мышью.
        /// </summary>
        private Action<Graphics> DragPaint
        {
            get
            {
                switch (_figure)
                {
                    case FigureKind.None:
                        _dragPaint = null;
                        break;
                    case FigureKind.Circle:
                        _dragPaint = args =>
                        {
                            args.DrawEllipse(
                                _dragColor.DashPen(), _startPoint.GetRectangle(_endPoint, IsEqual));
                        };
                        break;
                    case FigureKind.Rectangle:
                        _dragPaint = args =>
                        {
                            args.DrawRectangle(
                                _dragColor.DashPen(), _startPoint.GetRectangle(_endPoint, IsEqual));
                        };
                        break;
                    case FigureKind.Line:
                        _dragPaint = args =>
                        {
                            args.DrawLine(
                                _dragColor.DashPen(), _startPoint, _endPoint);
                        };
                        break;
                }
                return _dragPaint;
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
            };
        }

        #region Обработчики событий
        private void clearButton_Click(object sender, EventArgs e)
        {
            StartNewSketch();
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                _currentColor = colorDialog1.Color;
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
            _isPressed = false;
            AddAction();
            sketchPanel.Invalidate();
        }

        private void sketchPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            foreach (Action<Graphics> ac in _actions)
                ac(e.Graphics);
            if (_isPressed)
                DragPaint?.Invoke(e.Graphics);
        }
        #endregion

        #region Методы
        /// <summary>
        /// Создаём кнопки для рисования фигур
        /// </summary>
        private void CreateButtons()
        {
            toolStrip1.Items.Clear();
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
                toolStrip1.Items.Add(btn);
            }
        }

        /// <summary>Получить рисунок</summary>
        public Bitmap GetSketch()
        {
            var bmp = new Bitmap(sketchPanel.Width, sketchPanel.Height);
            sketchPanel.DrawToBitmap(bmp, sketchPanel.Bounds);
            return bmp;
        }

        /// <summary>
        /// Добавить метод рисования
        /// </summary>
        private void AddAction()
        {
            var path = new GraphicsPath();
            switch (_figure)
            {
                case FigureKind.Circle:
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
                    return;
            }
            var param = new Params
            {
                Path = path,
                Pen = (Pen)_currentColor.Pen((float)penWidthNumericUpDown.Value).Clone()
            };
            _actions.Add(g => g.DrawPath(param.Pen, param.Path));
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