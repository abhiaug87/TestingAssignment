using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace UITests.Data
{
    class JSON
    {
        private readonly string filepath = "../UITests/Data/";

        public string jsonReader(string fileName, object itemName)
        {
            string reportPath = filepath + fileName;


            // read JSON directly from a file
            StreamReader file = File.OpenText(reportPath);

            JsonTextReader reader = new JsonTextReader(file);
            {
                JObject o2 = (JObject)JToken.ReadFrom(reader);

                dynamic fileContents = JArray.Parse("[" + o2.ToString() + "]");
                dynamic fileContent = fileContents[0];
                var value = o2[itemName].ToString();
                return value;
            }
        }
    }
}