using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Microsoft.VisualBasic.FileIO;
using System.IO;

namespace Drive_Test_Formatter
{
    class XmlData
    {
        public string Text { get; set; }
        public int fileIndex { get; set; }
        private XElement datapoint;
        private int numColumns;
        public int NumColumns {
            get
            {
                return numColumns;
            }
        }

        public XmlData(string csvLine)
        {
            TextFieldParser parser = new TextFieldParser(new StringReader(csvLine));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            string[] fields = parser.ReadFields();
            parser.Close();
            if (fields == null) return;
            numColumns = fields.Length;
            if (fields[0] != null && fields[0] != "" && fields[1] != null && fields[1] != "" && fields[2] != null && fields[2] != "")
            {
                datapoint = new XElement("datapoint",
                new XElement("longitude", fields[0]),
                new XElement("latitude", fields[1]),
                new XElement("time", fields[2])
                );

                fileIndex = 0;
                for (int i = 3; i < fields.Length; i++)
                {
                    if (fields[i] == "" || fields[i] == null)
                    {
                        if (i % 2 != 0) fileIndex++;
                    }
                    else
                    {
                        XElement freq = new XElement("freq", (int)(Double.Parse(fields[i].Substring(0, fields[i].IndexOf(','))) / 1000000));
                        XElement power = new XElement("power", fields[i + 1].Substring(0, fields[i + 1].IndexOf(',')));
                        datapoint.Add(freq);
                        datapoint.Add(power);
                        break;
                    }
                }
                Text = datapoint.ToString();
            }
            else
            {
                Text = "";
            }
        }
    }
}
