using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

//csc -target:library Reader.cs Writer.cs

namespace Reader
{
    public interface ICSVFileReader
    {
        List<string> getLines();

        List<string[]> getDatas();

        
    }


    public class Reader: ICSVFileReader
    {
        private string filePath;
        private string encoding;
        private List<string> lines;
        private List<string[]> datas;

        public Reader(string filePath, string encoding)
        {
            this.filePath = filePath;
            this.encoding = encoding;
            this.lines = new List<string>();
            this.datas = new List<string[]>();
            Read();
        }

        private void Read()
        {
        
            using (StreamReader reader = new StreamReader(filePath, System.Text.Encoding.GetEncoding(encoding)))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    lines.Add(line);
                    string[] rowData = ParseCSVLine(line);
                    datas.Add(rowData);
                }
            }
        }

        private string[] ParseCSVLine(string line)
        {
            string camma= ",";
            string[] rowData = line.Split(camma[0]);
            return rowData;
        }

        //override
        public List<string> getLines()
        {
            return lines;
        }

        //override
        public List<string[]> getDatas()
        {
            return datas;
        }

        public void Config()
        {
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}