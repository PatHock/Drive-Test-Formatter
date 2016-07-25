using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Drive_Test_Formatter
{
    class XmlBuilder
    {
        public static string buildXml(List<XmlData> nodes, string rootElementName="root"){
            string xml = "<" + rootElementName + ">" + Environment.NewLine;
            foreach (XmlData data in nodes)
            {
                xml += data.Text + Environment.NewLine;
            }
            xml += "</" + rootElementName + ">";
            return xml;
        }
    }
}
