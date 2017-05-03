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
        /// <summary>���������� �������</summary>
        [XmlElement("Text")]
        public Caption Caption { get; set; }

        /// <remarks/>
        /// <summary>�������� �������</summary>
        public Cases Cases { get; set; }

        /// <remarks/>
        /// <summary>������������� �������</summary>
        [XmlAttribute("id")]
        public byte Id { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}, {1}", Id, Caption);
        }
    }
}