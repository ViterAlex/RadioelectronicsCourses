using System.ComponentModel;

namespace Controls
{
    public enum ToolKind
    {
        None = 0,

        [Description("������")]
        [Tool("EllipseToolIcon", "EllipseToolCursor")]
        Ellipse = 1,

        [Description("�������������")]
        [Tool("RectangleToolIcon", "RectangleToolCursor")]
        Rectangle = 2,

        [Description("������")]
        [Tool("LineToolIcon", "LineToolCursor")]
        Line = 3,

        [Description("������")]
        [Tool("EraserToolIcon", "EraserToolCursorMouseDown")]
        Eraser = 4,

        [Description("�����")]
        [Tool("TextToolIcon", "TextToolCursor")]
        Text = 5
    }

    public enum ShapeFillMode
    {
        [Description("������ ������")]
        [Tool("StrokeOnly")]
        StrokeOnly,

        [Description("������ �������")]
        [Tool("FillOnly")]
        FillOnly,

        [Description("������� � ������")]
        [Tool("StrokeAndFill")]
        StrokeAndFill
    }
}