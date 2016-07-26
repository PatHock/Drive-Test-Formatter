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

        //normalize EOL chars to that of the current system
        public string normalizeLineEndings(string data)
        {
            return Regex.Replace(data, @"\r\n|\n\r|\n|\r", Environment.NewLine);
        }



        public string[] XMLtoCSV()
        {
            // Take XML formatted drive data and convert to a string in CSV format
            // Each index in the array represents the CSV for one node
            string[] csvOutputs = new string[this.NumNodesUsed];

            //first line is always the same for all CSVs, writes the first line (column names)
            for (int i=0; i<NumNodesUsed; i++)
            {
                csvOutputs[i] = "Position - Longitude (WGS84),Position - Latitude (WGS84),Time,Frequency,Power";
            }

            // Adds the actual data for each CSV
            for (int i=0; i<XmlNodes.Count; i++)
            {
                // not going to use the variable 'i' here, need to somehow determine which file each XML node belongs to
                //TODO: write dank regex 
                csvOutputs[i] = Environment.NewLine; // += conversion here
            }

            /*
             * foreach (XmlData node in XmlNodes)
            {
                string csvLine = //convert node.Text to CSV format
            csvOutputs[node.FileIndex].add(csvLine);
            
            }
            */
            
            return csvOutputs;
}



    }
}
