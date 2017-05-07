using System.ComponentModel;

namespace MeshAnalysis.Controls
{
    public enum FigureKind
    {
        None,
        [Description("������")]
        Ellipse,
        [Description("�������������")]
        Rectangle,
        [Description("������")]
        Line
    }

    public enum DrawMode
    {
        [Description("������ ������")]
        StrokeOnly,
        [Description("������ �������")]
        FillOnly,
        [Description("������� � ������")]
        StrokeAndFill
    }
}