using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Controls.Tools
{
    public static class ToolFactory<TTool> where TTool : Tool, new()
    {
        public static TTool CreateTool(Control parent, Color fill)
        {
            return new TTool()
            {
                Fill = new SolidBrush(fill),
                Parent = parent
            };
        }
        public static TTool CreateTool(Control parent, Color stroke, float width)
        {
            return new TTool()
            {
                Stroke = new Pen(stroke, width),
                Parent = parent

            };
        }
        public static TTool CreateTool(Control parent, Color fill, Color stroke, float width)
        {
            return new TTool()
            {
                Fill = new SolidBrush(fill),
                Stroke = new Pen(stroke, width),
                Parent = parent
            };
        }
        public static TTool CreateTool(Control parent, float radius)
        {
            return new TTool()
            {
                Radius = radius,
                Parent = parent
            };
        }
        public static TTool CreateTool(Control parent, Font font, Color fill)
        {
            return new TTool()
            {
                Fill = new SolidBrush(fill),
                Font = font,
                Parent = parent
            };
        }
    }
}
