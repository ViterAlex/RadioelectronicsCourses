using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeshAnalysis.Properties;

namespace MeshAnalysis.Controls
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class ImageAttribute : Attribute
    {
        public ImageAttribute(string resourceImage)
        {
            Image = (Image) Resources.ResourceManager.GetObject(resourceImage);
        }
        public Image Image { get; }
    }
}
