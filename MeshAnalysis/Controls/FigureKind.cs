using System.ComponentModel;

namespace MeshAnalysis.Controls
{
    public enum FigureKind
    {
        None,
        [Description("Эллипс")]
        Ellipse,
        [Description("Прямоугольник")]
        Rectangle,
        [Description("Прямая")]
        Line
    }

    public enum DrawMode
    {
        [Description("Только контур")]
        StrokeOnly,
        [Description("Только заливка")]
        FillOnly,
        [Description("Заливка и контур")]
        StrokeAndFill
    }
}