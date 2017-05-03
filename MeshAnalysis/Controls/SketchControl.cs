using System;
using System.Drawing;
using System.Windows.Forms;

namespace MeshAnalysis.Controls
{
    public partial class SketchControl : UserControl
    {
        Color CurrentColor = Color.White;
        bool isPressed = false;
        Point CurrentPoint;
        Point PrevPoint;
        Graphics g;
        int t = 5, h = 5;

        public SketchControl()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }
        //Рисование

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                t = Convert.ToInt32(numericUpDown1.Value);
                h = Convert.ToInt32(numericUpDown1.Value);
                using (SolidBrush brush = new SolidBrush(colorDialog1.Color))
                {
                    g.FillEllipse(brush, e.X, e.Y, t, h);
                }
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
        }

        private void selectColorButton_Click(object sender, EventArgs e)
        {
            DialogResult D = colorDialog1.ShowDialog();
            if (D == System.Windows.Forms.DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        public void StartNewSketch()
        {
            panel1.Refresh();
        }

        public Bitmap GetSketch()
        {
            var bmp = new Bitmap(panel1.Width, panel1.Height);
            panel1.DrawToBitmap(bmp, panel1.Bounds);
            return bmp;
        }
    }
}
