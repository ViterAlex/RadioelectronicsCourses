using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Xml.Serialization;

namespace MeshAnalysis
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Excercise
    {
        /// <remarks/>
        public Caption Text { get; set; }

        /// <remarks/>
        public Cases Cases { get; set; }

        /// <remarks/>
        [XmlAttribute("id")]
        public byte Id { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}, {1}", Id, Text);
        }

        public Image GetImage()
        {
            if (Text.ImageBase64 == null || Text.ImageBase64.Source.Length == 0)
            {
                return null;
            }
            return Base64ToImage(Text.ImageBase64.Source.Substring(22));
        }

        private Image Base64ToImage(string base64String)
        {
            // Convert base 64 string to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }
        public static string ImageToBase64(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
}