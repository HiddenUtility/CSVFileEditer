using System;
using System.IO;
using System.Collections.Generic;

namespace CsUtil.CsvUtil{
    public class SettingCsvReader
    {
        private string _csvFilepath;
        private char _delimiter = ',';
        private string[] _headers;

        private List<Dictionary<string, string>> _dataFrame;

        public SettingCsvReader(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
            {
                throw new Exception($"{csvFilePath}は存在しません。");
            }
            _csvFilepath = csvFilePath;
            _dataFrame = new List<Dictionary<string, string>>();
            try
            {
                Load();
            }
            catch (Exception e)
            {
                throw new Exception($"{e}\n {csvFilePath}の読み取りに失敗しました。");
            }

        }


        private void Load()
        {
            using (StreamReader reader = new StreamReader(_csvFilepath))
            {
                string headerLine = reader.ReadLine();
                _headers = headerLine.Split(_delimiter);
                
                // ヘッダーチェックはよそでやってもらう
                while (!reader.EndOfStream)
                {
                    var data = new Dictionary<string, string>();
                    string line = reader.ReadLine();
                    string[] values = line.Split(_delimiter);
                    for (int i = 0; i < _headers.Length; i++)
                    {
                        data[_headers[i]] = values[i];
                    }
                    _dataFrame.Add(data);
                }
            }
        }

        public string[] Headers { get => _headers; }

        public List<Dictionary<string, string>> ToDataFrame()
        {
            return _dataFrame;
        }

    }

}

