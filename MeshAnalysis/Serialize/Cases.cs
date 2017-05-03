using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace MeshAnalysis
{
    /// <remarks/>
    [Serializable]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Cases 
    {
        [XmlIgnore]
        public Case this[int index]
        {
            get
            {
                return CaseList[index];
            }
            set
            {
                CaseList[index] = value;
            }
        }

        [XmlElement("Case")]
        public List<Case> CaseList { get; set; }

        /// <summary>Идентификатор правильного ответа, если подразумевается только один ответ на вопрос</summary>
        [XmlAttribute("caseId")]
        public byte CaseId { get; set; }

        public override string ToString()
        {
            return string.Format("Count = {0}, CaseId = {1}", CaseList.Count, CaseId);
        }
    }
}