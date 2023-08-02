

using System;
using Maker;

//csc Program.cs

namespace Test
{
    public class Test
    {
        public static void Main(string[] args)
        {
            
            string filepath = @"test.txt";
            string text = "test0\ntest1\ntest2";
            DummiyFileMaker.MakeDummiy(filepath, text);
        }
    }
}