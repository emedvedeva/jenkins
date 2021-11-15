using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TestProject1.Models;

namespace TestProject1.Utils
{
    public static class ConfigManager
    {
        private static string _configDataPath = Directory.GetCurrentDirectory() + @"\Resources\ConfigData.json";
        private static string _userDataPath = Directory.GetCurrentDirectory() + @"\Resources\user.json";

        public static string GetUrl()
        {
            //AqualityServices.LocalizedLogger.Info($"Getting url");
            return GetConfigData()["url"];
        }

        public static string GetData(string number)
        {
            //AqualityServices.LocalizedLogger.Info($"Getting data for {number}");
            return GetConfigData()[number];
        }

        public static User GetUserFromFile()
        {
            //AqualityServices.LocalizedLogger.Info("Getting user from file");
            return JsonConvert.DeserializeObject<User>(File.ReadAllText(_userDataPath));
        }

        private static Dictionary<string, string> GetConfigData()
        {
            //AqualityServices.LocalizedLogger.Info("Getting configData from file");
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText(_configDataPath));
        }
    }
}
