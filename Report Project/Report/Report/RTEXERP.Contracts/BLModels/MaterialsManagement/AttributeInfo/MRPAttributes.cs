using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace RTEXERP.Contracts.BLModels.MaterialsManagement.AttributeInfo
{
    [XmlRoot(ElementName = "Attributes")]
    public class MRPAttributes
    {
        public MRPAttributes()
        {
            MRPAttribute = new List<MRPAttribute>();
        }
        [XmlAttribute(AttributeName = "MRPItemCode")]
        public int MRPItemCode { get; set; }
        [XmlAttribute(AttributeName = "MRPItemName")]
        public string MRPItemName { get; set; }
        [XmlAttribute(AttributeName = "AttributeInstanceID")]
        public long AttributeInstanceID { get; set; }
        [XmlElement(ElementName = "Attribute")]
        public List<MRPAttribute> MRPAttribute { get; set; }
    }

    [XmlRoot(ElementName = "Attribute")]
    public class MRPAttribute
    {
        [XmlAttribute(AttributeName = "ID")]
        public int ID { get; set; }
        [XmlAttribute(AttributeName = "Name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "DefaultValue")]
        public string DefaultValue { get; set; }
        [XmlAttribute(AttributeName = "ValueDescription")]
        public string ValueDescription { get; set; }

        [XmlAttribute(AttributeName = "Priority")]
        public int Priority { get; set; }

        [XmlAttribute(AttributeName = "Type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "ColorName")]
        public string ColorName { get; set; }

        [XmlAttribute(AttributeName = "IsHighLevel")]
        public int IsHighLevel { get; set; }
        [XmlAttribute(AttributeName = "AttributeType")]
        public int AttributeType { get; set; }

        [XmlText]
        public string Text { get; set; }
    }
}
