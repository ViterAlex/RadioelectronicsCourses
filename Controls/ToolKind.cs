using System.ComponentModel;

namespace Controls
{
    public enum ToolKind
    {
        None = 0,

        [Description("Эллипс")]
        [Tool("EllipseToolIcon", "EllipseToolCursor")]
        Ellipse = 1,

        [Description("Прямоугольник")]
        [Tool("RectangleToolIcon", "RectangleToolCursor")]
        Rectangle = 2,

        [Description("Прямая")]
        [Tool("LineToolIcon", "LineToolCursor")]
        Line = 3,

        [Description("Ластик")]
        [Tool("EraserToolIcon", "EraserToolCursorMouseDown")]
        Eraser = 4,

        [Description("Текст")]
        [Tool("TextToolIcon", "TextToolCursor")]
        Text = 5
    }

    public enum ShapeFillMode
    {
        [Description("Только контур")]
        [Tool("StrokeOnly")]
        StrokeOnly,

        [Description("Только заливка")]
        [Tool("FillOnly")]
        FillOnly,

        [Description("Заливка и контур")]
        [Tool("StrokeAndFill")]
        StrokeAndFill
    }
}