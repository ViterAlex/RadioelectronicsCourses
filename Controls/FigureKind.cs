using System.ComponentModel;

namespace Controls
{
    public enum FigureKind
    {
        None,
        [Description("Эллипс"), Image("EllipseToolIcon")] Ellipse,
        [Description("Прямоугольник"), Image("RectangleToolIcon")] Rectangle,
        [Description("Прямая"), Image("LineToolIcon")] Line
    }

    public enum ShapeFillMode
    {
        [Description("Только контур"), Image("StrokeOnly")] StrokeOnly,
        [Description("Только заливка"), Image("FillOnly")] FillOnly,
        [Description("Заливка и контур"), Image("StrokeAndFill")] StrokeAndFill
    }
}