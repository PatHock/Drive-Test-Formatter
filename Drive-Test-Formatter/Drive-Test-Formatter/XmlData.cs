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

        public int NumNodesUsed
        {
            get
            {
                return (numColumns - 3) % 2;
            }
        }

        public XmlData(string csvLine)
        {
            //read all the fields of the CSV line
            TextFieldParser parser = new TextFieldParser(new StringReader(csvLine));
            parser.HasFieldsEnclosedInQuotes = true;
            parser.SetDelimiters(",");
            string[] fields = parser.ReadFields();
            parser.Close();
            //if the line is empty, return
            if (fields == null) return;
            numColumns = fields.Length;
            //if the longitude, latitude, and time fields are all non-null, add them as an XML element
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
                        //columns Frequency and Power are a 2-column pair, so only increment ever OTHER column
                        if (i % 2 != 0) fileIndex++;
                    }
                    else
                    {
                        //add frequency and power as XML elements
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
