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

        //constructor
        public DriveTestData(string inputData){
            inputData = normalizeLineEndings(inputData);
            string headersLine = inputData.Substring(0, inputData.IndexOf(Environment.NewLine));
            NumNodesUsed = Regex.Matches(headersLine, "Frequency").Count;
            inputData = inputData.Substring(inputData.IndexOf(Environment.NewLine) + 1);
            string[] lines = inputData.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            XmlNodes = new List<XmlData>();
            foreach (string line in lines)
            {
                if (!line.StartsWith("\"\""))
                {
                    XmlData node = new XmlData(line);
                    XmlNodes.Add(node);
                }
            }
        }

        //normalize EOL chars to that of the current system
        public string normalizeLineEndings(string data)
        {
            return Regex.Replace(data, @"\r\n|\n\r|\n|\r", Environment.NewLine);
        }



        public string[] XMLtoCSV()
        {
            // Take XML formatted drive data and convert to a string in CSV format
            // Each index in the array represents the CSV for one node
            string[] csvOutputs = new string[NumNodesUsed];

            //first line is always the same for all CSVs, writes the first line (column names)
            for (int i=0; i<NumNodesUsed; i++)
            {
                csvOutputs[i] = "Position - Longitude (WGS84),Position - Latitude (WGS84),Time,Frequency,Power";
            }

            // Adds the actual data for each CSV
            for (int i=0; i<XmlNodes.Count; i++)
            {
                //TODO: write dank regex
                csvOutputs[XmlNodes[i].fileIndex] += (Environment.NewLine + Regex.Match(XmlNodes[i].Datapoint.Nodes().ToList()[0].ToString(), @"-?\d{1,3}\.\d{0,8}") + "," +
                     Environment.NewLine + Regex.Match(XmlNodes[i].Datapoint.Nodes().ToList()[1].ToString(), @"-?\d{1,3}\.\d{0,8}") + "," +
                     Environment.NewLine + Regex.Match(XmlNodes[i].Datapoint.Nodes().ToList()[2].ToString(), @"\d{1,2}:\d{2}:\d{2}") + "," +
                     Environment.NewLine + Regex.Match(XmlNodes[i].Datapoint.Nodes().ToList()[3].ToString(), @"\d{3,4}") + "," +
                     Environment.NewLine + Regex.Match(XmlNodes[i].Datapoint.Nodes().ToList()[4].ToString(), @"-?\d{1,3}\.\d{1,4}"));
            }

            return csvOutputs;
}



    }
}
