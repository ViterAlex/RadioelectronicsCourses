using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using static Controls.Properties.Resources;

namespace Controls
{
    /// <summary>
    /// Дополнительные свойства инструментова рисования: подсказки, иконки, курсоры
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    internal class ToolAttribute : Attribute
    {

        public ToolAttribute(string image)
        {
            Image = (Image)ResourceManager.GetObject(image);
        }

        public ToolAttribute(string image, string cursor)
            : this(image)
        {
            var o = ResourceManager.GetObject(cursor);
            if (o == null) return;
            using (var stream = new MemoryStream((byte[])o))
            {
                ToolCursor = new Cursor(stream);
            }
        }
        /// <summary>
        /// Изображение для инструмента
        /// </summary>
        public Image Image { get; }
        /// <summary>
        /// Курсор для инструмента
        /// </summary>
        public Cursor ToolCursor { get; }
    }
}
