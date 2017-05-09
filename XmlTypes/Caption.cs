using System;
using System.ComponentModel;
using System.Drawing;
using System.Xml.Serialization;

namespace XmlTypes
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Caption
    {
        /// <summary>Иллюстрация к вопросу</summary>
        [XmlElement("img")]
        public Illustration ImageBase64 { get; set; }

        /// <summary>Текст вопроса</summary>
        [XmlText]
        public string Text { get; set; }

        public Image GetImage()
        {
            if (ImageBase64 == null || ImageBase64.Source.Length == 0)
            {
                return null;
            }
            return ImageBase64.Source.Base64ToImage();
            //return Base64ToImage(Caption.ImageBase64.Source.Substring(22));
        }

        public override string ToString()
        {
            return Text.Trim();
        }
    }
}