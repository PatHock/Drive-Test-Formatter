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
        public int NumNodesUsed { get; set; }
        public DriveTestData(string inputData, Boolean hasHeaders=true){
            inputData = normalizeLineEndings(inputData);
            if (hasHeaders) inputData = inputData.Substring(inputData.IndexOf(Environment.NewLine) + 1);
            string[] lines = inputData.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            XmlNodes = new List<XmlData>();
            foreach (string line in lines)
            {
                XmlData node = new XmlData(line);
                NumNodesUsed = node.NumNodesUsed;
                XmlNodes.Add(node);
            }
        }

        public string normalizeLineEndings(string data)
        {
            return Regex.Replace(data, @"\r\n|\n\r|\n|\r", Environment.NewLine);
        }
        //public string csvOutputs;

        // Take XML formatted drive data and convert to a string in CSV format
        List<string>[] csvOutputs = new List<string>[NumNodesUsed]();
        foreach(List<string> list in csvOutputs){
	        list = new List<string>();
        }
        foreach(XmlData node in XmlNodes){
	        string csvLine = //convert node.Text to CSV format
        csvOutputs[node.FileIndex].add(csvLine);
}



    }
}
