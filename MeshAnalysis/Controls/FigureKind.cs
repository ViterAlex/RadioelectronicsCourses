using System.ComponentModel;
using System.Drawing;
using MeshAnalysis.Properties;

namespace MeshAnalysis.Controls
{
    public enum FigureKind
    {
        None,
        [Description("������")]
        [Image("EllipseToolIcon")]
        Ellipse,
        [Description("�������������")]
        [Image("RectangleToolIcon")]
        Rectangle,
        [Description("������")]
        [Image("LineToolIcon")]
        Line
    }

    public enum DrawMode
    {
        [Description("������ ������")]
        [Image("StrokeOnly")]
        StrokeOnly,
        [Description("������ �������")]
        [Image("FillOnly")]
        FillOnly,
        [Description("������� � ������")]
        [Image("StrokeAndFill")]
        StrokeAndFill
    }
}