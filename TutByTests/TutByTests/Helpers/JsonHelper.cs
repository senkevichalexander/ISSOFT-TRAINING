using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace TutByTests.Helpers
{
    public static class JsonHelper
    {
        private static readonly string jsonName = "appSettings.json";

        public static Dictionary<string, string> GetDictiinaryFromJSON()
        {
            var json = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(jsonName));
            return json;
        }
    }
}
