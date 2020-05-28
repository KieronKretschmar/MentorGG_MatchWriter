using MatchEntities;
using Microsoft.DotNet.PlatformAbstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MatchWriterTestProject
{
    public static class TestHelper
    {
        public static readonly string TestDataFolderName = "TestData";

        public static string GetTestFilePath(string fileName)
        {
            var path = Path.Combine(GetTestDataFolderPath(), fileName);
            if (path.EndsWith(".dem") && !File.Exists(path))
            {
                throw new FileNotFoundException(".dem not found. You need to unzip it in order to run tests, since the unzipped file is too large for the repo.");
            }
            return path;
        }

        public static string GetTestDataFolderPath()
        {
            string startupPath = ApplicationEnvironment.ApplicationBasePath;
            var pathItems = startupPath.Split(Path.DirectorySeparatorChar);
            var pos = pathItems.Reverse().ToList().FindIndex(x => string.Equals("bin", x));
            string projectPath = String.Join(Path.DirectorySeparatorChar.ToString(), pathItems.Take(pathItems.Length - pos - 1));
            return Path.Combine(projectPath, TestDataFolderName);
        }

        public static long GetMatchIdFromJson(string json)
        {
            var data = JsonConvert.DeserializeObject<MatchDataSet>(json);
            return data.MatchStats.MatchId;
        }

        /// <summary>
        /// Provides the same settings as MatchDataSet.ToJson().
        /// </summary>
        /// <returns></returns>
        public static JsonSerializerSettings GetJsonSerializerSettings()
        {
            return new JsonSerializerSettings
            {
                DateFormatHandling = DateFormatHandling.IsoDateFormat,
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented
            };
        }
    }
}
