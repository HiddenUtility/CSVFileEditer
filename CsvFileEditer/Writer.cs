using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace Writer
    {
    public interface IWriter
    {
        void WriteLine(string line);

        void WriteData(string[] data);

        void ToCsv(string filepath, string encoding);
    }

    public class Writer : IWriter
    {
        private List<string> lines;
        private List<string[]> datas;
        public Writer()
        {
            this.lines = new List<string>();
            this.datas = new List<string[]>();
        }

        public void WriteLine(string line)
        {
            lines.Add(line);
        }

        public void WriteData(string[] data)
        {
            string line = String.Join(",", data);
            WriteLine(line);
            datas.Add(data);
        }

        public void ToCsv(string filepath, string encoding)
        {

            StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.GetEncoding(encoding));
            foreach (string line in lines)
            {
                sw.WriteLine(line);
            }
            sw.Close();

            
        }


    }
}