using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MeshAnalysis
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
        [XmlAttribute, EditorBrowsable(EditorBrowsableState.Never)]
        public string alt { get; set; }
    }
}