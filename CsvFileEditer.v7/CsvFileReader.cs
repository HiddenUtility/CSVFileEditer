using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


public interface ICSVFileReader
{
    public List<string> getLines();

    public List<string[]> getDatas();

    
}


public class CSVReader: ICSVFileReader
{
    private string filePath;
    private string encoding;
    private List<string> lines;
    private List<string[]> datas;

    public CSVReader(string filePath, string encoding)
    {
        this.filePath = filePath;
        this.encoding = encoding;
        this.lines = new List<string>();
        this.datas = new List<string[]>();
        Read();
    }

    private void Read()
    {
        Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
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
        
        string[] rowData = line.Split(",");
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