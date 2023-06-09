using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

public interface ICSVFileWriter
{
    public void WriteLine(string line);

    public void WriteData(string[] data);

    public void ToCsv(string filepath, string encoding);
}

public class CSVWriter : ICSVFileWriter
{
    private List<string> lines;
    private List<string[]> datas;
    public CSVWriter()
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
        Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        StreamWriter sw = new StreamWriter(filepath, false, System.Text.Encoding.GetEncoding(encoding));
        foreach (string line in lines)
        {
            sw.WriteLine(line);
        }
        sw.Close();

        
    }


}