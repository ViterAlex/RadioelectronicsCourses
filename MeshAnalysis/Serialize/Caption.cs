using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MeshAnalysis
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Caption
    {
        [XmlElement("img")]
        public Illustration ImageBase64 { get; set; }
        /// <remarks/>
        [XmlText]
        public string Text { get; set; }

        public override string ToString()
        {
            
            return Text.Trim();
        }
    }
}