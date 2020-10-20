using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace UnitTestProject.ExtensionMethods
{
    public static class TableExtensions
    {
        public static Dictionary<string, string> ToDictionary(this Table table)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var row in table.Rows)
            {
                dictionary[row[0]] = row[1].Trim();
            }
            return dictionary;
        }

        public static Dictionary<string, string> ToDictionary(this Table headers, params string[] values)
        {
            var dictionary = new Dictionary<string, string>();
            var keys = headers.Header.ToArray();
            
            for (int i = 0; i < keys.Length; i++)
            {
                dictionary[keys[i]] = values[i].Trim('\'');
            }
            return dictionary;
        }

        public static List<string> ToList(this Table table)
        {
            var list = new List<string>();
            foreach (var row in table.Rows)
            {
                list.Add(row[0]);
            }
            return list;
        }
    }
}