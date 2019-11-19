using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Entities
{
    public class MatchDataSet
    {
        public List<List<IMatchDataEntity>> Tables { get; set; } = new List<List<IMatchDataEntity>>();

        public MatchDataSet(string version, string json)
        {
            if(version > "")
            {

            }
        }

        /// <summary>
        /// Serializes object to JSON using the correct configuration.
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter(sb);
            JsonWriter jsonWriter = new JsonTextWriter(sw);

            JsonSerializer serializer = new JsonSerializer();
            serializer.Converters.Add(new Newtonsoft.Json.Converters.JavaScriptDateTimeConverter());
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.TypeNameHandling = TypeNameHandling.Auto;
            serializer.Formatting = Formatting.Indented;
            serializer.Serialize(jsonWriter, this);

            var json = sw.ToString();

            JsonConvert.SerializeObject(this);

            return json;
        }

        public void AssignMatchId(long matchId)
        {
            foreach (var table in Tables)
            {
                foreach (var entry in table)
                {
                    entry.MatchId = matchId;
                }
            }
        }



    }

}
