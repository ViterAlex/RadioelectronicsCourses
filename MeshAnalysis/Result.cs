using System.Drawing;
using XmlTypes;

namespace MeshAnalysis
{
    internal class Result
    {
        public Excercise Excercise { get; set; }
        public string Message { get; set; }
        public Image Sketch { get; set; }
        public string Notes { get; set; }
    }
}
