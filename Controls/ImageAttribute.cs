using System;
using System.Drawing;
using Controls.Properties;

namespace Controls
{
    /// <summary>
    /// Определяет имя ресурса изображения для данного поля
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    internal class ImageAttribute : Attribute
    {
        public ImageAttribute(string resourceImage)
        {
            Image = (Image)Resources.ResourceManager.GetObject(resourceImage);
        }
        public Image Image { get; }
    }
}
