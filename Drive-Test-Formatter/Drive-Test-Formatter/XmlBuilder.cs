using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Drive_Test_Formatter
{
    class XmlBuilder
    {
        public static XElement buildXml(List<XElement> nodes, string rootElementName="root"){
            XElement root = new XElement(rootElementName);
            foreach(XElement element in nodes){
                root.Add(element);
            }
            return root;
        }
    }
}
