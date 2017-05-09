using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace XmlTypes
{

    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Excercises
    {
        [XmlAttribute("title")]
        public string Title { get; set; }

        [XmlAttribute("theory")]
        public string Theory { get; set; }

        [XmlIgnore]
        public Excercise this[int index]
        {
            get
            {
                return ExcerciseList[index];
            }
            set
            {
                ExcerciseList[index] = value;
            }
        }

        [XmlElement("Excercise")]
        public List<Excercise> ExcerciseList { get; set; }

        public int Count
        {
            get
            {
                return ExcerciseList.Count;
            }
        }
    }
}
