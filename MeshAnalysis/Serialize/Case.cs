using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MeshAnalysis
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Case
    {
        /// <remarks/>
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlAttribute("si")]
        public string Si { get; set; }

        /// <remarks/>
        [XmlText]
        public string Value { get; set; }

        #region Overrides of Object

        public override string ToString()
        {
            return Value;
        }

        #endregion
    }
}