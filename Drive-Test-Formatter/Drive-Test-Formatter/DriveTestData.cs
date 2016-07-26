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
        public DriveTestData(string inputData, Boolean hasHeaders=true){
            inputData = normalizeLineEndings(inputData);
            string[] lines = inputData.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
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
// Comment for testing, Pushing from VS
