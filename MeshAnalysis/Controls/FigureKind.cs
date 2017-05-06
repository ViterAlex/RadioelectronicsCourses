using System.ComponentModel;

namespace MeshAnalysis.Controls
{
    internal enum FigureKind
    {
        None,
        [Description("Окружность")]
        Circle,
        [Description("Прямоугольник")]
        Rectangle,
        [Description("Прямая")]
        Line
    }
}