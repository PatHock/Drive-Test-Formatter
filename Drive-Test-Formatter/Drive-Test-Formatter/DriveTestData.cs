using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Drive_Test_Formatter
{
    class DriveTestData
    {
        private Dictionary<string, List<string>> data;
        public Dictionary<string, List<string>> Data { get; set; }
        private Boolean hasHeaders;
        public Boolean HasHeaders { get; }
        private string[] headers;
        public string[] Headers { get; set; }

        public DriveTestData(string inputData, Boolean includesHeaders=true){
            hasHeaders = includesHeaders;
            inputData = normalizeLineEndings(inputData);
            if (HasHeaders)
            {
                string headerString = inputData.Substring(0, inputData.IndexOf(Environment.NewLine));
                headers = headerString.Split(',');
                inputData = inputData.Substring(inputData.IndexOf(Environment.NewLine) + 1);
            }
            string[] lines = inputData.Split(new string[] {Environment.NewLine}, StringSplitOptions.None);
            for (int i = 0; i < lines.Length; i++)
            {
                string[] lineFields = lines[i].Split(',');
                //if it doesn't have a long/lat field, drop this record
                if (cellIsNullOrEmpty(lineFields[0]) || cellIsNullOrEmpty(lineFields[1]))
                {
                    continue;
                }
                if (hasHeaders)
                {
                    int numNodes = 1;
                    for (int x = 0; x < headers.Length; x++)
                    {
                        if (headers.Length > 5)
                        {
                            if (x > 3)
                            {
                                headers[x] = headers[x] + numNodes;
                                //we want frequency 1 to match power 1 and so on
                                //so only increment EVERY OTHER iteration
                                if (x % 2 == 0) numNodes++;
                            }
                        }
                        data.Add(headers[x], new List<string>());
                    }
                }
                else
                {
                    for (int x = 0; x < lineFields.Length; x++)
                    {
                        data.Add("" + x, new List<string>());
                    }
                }
                for (int j = 0; j < lineFields.Length; j++)
                {
                    if (hasHeaders)
                    {
                        data[headers[j]].Add(lineFields[j]);
                    }
                    else
                    {
                        data["" + j].Add(lineFields[j]);
                    }
                }
            }
        }

        public int getNumNodes()
        {
            return (headers.Length - 3) % 2;
        }

        public Boolean cellIsNullOrEmpty(string cell){
            return cell == null || cell == "\"\"";
        }

        public string normalizeLineEndings(string data)
        {
            return Regex.Replace(data, @"\r\n|\n\r|\n|\r", Environment.NewLine);
        }
    }
}
