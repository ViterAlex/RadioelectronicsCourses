using System.ComponentModel;

namespace MeshAnalysis.Controls
{
    internal enum FigureKind
    {
        None,
        [Description("����������")]
        Circle,
        [Description("�������������")]
        Rectangle,
        [Description("������")]
        Line
    }
}