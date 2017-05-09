using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XmlTypes
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Case
    {
        /// <summary>������������� ������</summary>>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>�������������� ����� � ������</summary>>
        [XmlAttribute("si")]
        public string Si { get; set; }

        /// <summary>���������� �����</summary>>
        [XmlText]
        public string Value { get; set; }

        public override string ToString()
        {
            return Value;
        }
    }
}