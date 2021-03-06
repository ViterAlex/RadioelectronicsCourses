using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XmlTypes
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Illustration
    {
        /// <remarks/>
        [XmlAttribute("src")]
        public string Source { get; set; }

        /// <remarks/>
        [XmlAttribute("alt"), EditorBrowsable(EditorBrowsableState.Never)]
        public string AltText { get; set; }
    }
}