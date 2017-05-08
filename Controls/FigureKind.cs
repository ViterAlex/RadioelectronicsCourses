using System.ComponentModel;

namespace Controls
{
    public enum FigureKind
    {
        None,
        [Description("������"), Image("EllipseToolIcon")] Ellipse,
        [Description("�������������"), Image("RectangleToolIcon")] Rectangle,
        [Description("������"), Image("LineToolIcon")] Line
    }

    public enum ShapeFillMode
    {
        [Description("������ ������"), Image("StrokeOnly")] StrokeOnly,
        [Description("������ �������"), Image("FillOnly")] FillOnly,
        [Description("������� � ������"), Image("StrokeAndFill")] StrokeAndFill
    }
}