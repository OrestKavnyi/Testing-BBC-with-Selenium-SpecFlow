using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject.FormData
{
    public static class DataGenerator
    {
        private static readonly Dictionary<string, Dictionary<string, string>> data = new Dictionary<string, Dictionary<string, string>>();

        public static void GenerateData()
        {
            new LoremHomePage().UncheckStartText().ClickGenerate();
            int i = 1;
            foreach (var paragraph in new ResultPage().Paragraphs)
            {
                var testData = new Dictionary<string, string>
                {
                    ["Tell us your story"] = paragraph.Length > 500 ? paragraph.Substring(0, 500) : paragraph,
                    ["Name"] = paragraph.Substring(0, paragraph.IndexOf(' ')),
                    ["I am over 16 years old"] = (paragraph.Length % 2 == 0) ? true.ToString() : false.ToString(),
                    ["Terms of Service"] = false.ToString()
                };
                data["TestCase" + i++] = testData;
            }
        }

        public static Dictionary<string, string> GetTestData(string key)
        {
            return data[key];
        }
    }
}