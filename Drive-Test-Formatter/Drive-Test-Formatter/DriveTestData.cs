using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Text.RegularExpressions;

namespace Drive_Test_Formatter
{
    class DriveTestData
    {
        public List<XmlData> XmlNodes { get; set; }
        public string XmlText
        {
            get
            {
                string text = "";
                foreach (XmlData node in XmlNodes)
                {
                    if(node.Text != "") text += node.Text + Environment.NewLine;
                }
                return text;
            }
        }
        public DriveTestData(string inputData, Boolean hasHeaders=true){
            inputData = normalizeLineEndings(inputData);
            if (hasHeaders) inputData = inputData.Substring(inputData.IndexOf(Environment.NewLine) + 1);
            string[] lines = inputData.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            XmlNodes = new List<XmlData>();
            foreach (string line in lines)
            {
                XmlNodes.Add(new XmlData(line));
            }
        }

        public string normalizeLineEndings(string data)
        {
            return Regex.Replace(data, @"\r\n|\n\r|\n|\r", Environment.NewLine);
        }
    }
}
