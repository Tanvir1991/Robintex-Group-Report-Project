﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RTEXERP.Common
{
    public static class Util
    {
        public static void LogToFile(string path, string logText)
        {
            if (!string.IsNullOrEmpty(logText))
            {
                File.AppendAllText(path, "\r\n\r\n" + System.DateTime.Now.ToString() + "\r\n" + logText);
            }
        }

        public static string GetValueFromNvpFile(string path, string name)
        {
            string rtnValue = string.Empty;
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split(new[] { '=' }, 2);
                string key = parts[0].Trim();
                string value = parts[1].Trim();

                if (key == name)
                {
                    rtnValue = value;
                    break;
                }
            }
            return rtnValue;
        }

        public static void SaveValueToNvpFile(string path, string name, string value)
        {
            string item = string.Empty;
            List<string> lines = new List<string>();
            foreach (string line in File.ReadLines(path))
            {
                string[] parts = line.Split(new[] { '=' }, 2);
                if (parts[0].Trim() == name)
                {
                    parts[1] = value;
                    item = parts[0] + "=" + parts[1];
                }
                else
                {
                    item = line;
                }
                lines.Add(item);
            }
            File.WriteAllLines(path, lines);
        }

        public static Dictionary<string, string> GetAllFromNvpFile(string path)
        {
            string[] lines = File.ReadAllLines(path);
            var dict = lines.Select(l => l.Split(new[] { '=' }, 2)).ToDictionary(a => a[0].Trim(), a => a[1].Trim());
            return dict;

            //Get items
            //var item = dict["item1"];
        }

        public static void SaveAllToNvpFile(string path, Dictionary<string, string> dict)
        {
            //Data entries
            //var dict = new Dictionary<string, string>
            //{
            //    { "name1", "value1" },
            //    { "name2", "value2" },
            //    // etc
            //}
            string[] lines = dict.Select(kvp => kvp.Key + "=" + kvp.Value).ToArray();
            File.WriteAllLines(path, lines);
        }

        public static bool IsFileReady(String sFilename)
        {
            // If the file can be opened for exclusive access it means that the file
            // is no longer locked by another process.
            try
            {
                using (FileStream inputStream = File.Open(sFilename, FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    if (inputStream.Length > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool IsNumeric(string value)
        {
            return _isNumericRegex.IsMatch(value);
        }
        private static readonly Regex _isNumericRegex = new Regex("^(" +
            /*Hex*/ @"0x[0-9a-f]+" + "|" +
            /*Bin*/ @"0b[01]+" + "|" +
            /*Oct*/ @"0[0-7]*" + "|" +
            /*Dec*/ @"((?!0)|[-+]|(?=0+\.))(\d*\.)?\d+(e\d+)?" +
            ")$");

        //String extension        
        public static string ReplaceFirst(this string text, string search, string replace)
        {
            int pos = text.IndexOf(search);
            if (pos < 0)
            {
                return text;
            }
            return text.Substring(0, pos) + replace + text.Substring(pos + search.Length);
        }
    }

    public class NameValue
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
