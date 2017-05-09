using System;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XmlTypes
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Excercise
    {
        /// <remarks/>
        /// <summary>Содержание вопроса</summary>
        [XmlElement("Text")]
        public Caption Caption { get; set; }

        /// <remarks/>
        /// <summary>Варианты ответов</summary>
        public Cases Cases { get; set; }

        /// <remarks/>
        /// <summary>Идентификатор вопроса</summary>
        [XmlAttribute("id")]
        public byte Id { get; set; }

        public override string ToString()
        {
            return string.Format("Id = {0}, {1}", Id, Caption);
        }
    }
}