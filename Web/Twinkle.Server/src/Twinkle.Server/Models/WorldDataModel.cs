using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Twinkle.Server.Models
{
    [JsonObject]
    public class GameWorldsCollection
    {
        public GameWorldData[] Worlds { get; set; }
    }

    [JsonObject]
    public class GameWorldData
    {
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public SoundData[] Sounds { get; set; }
    }


    [JsonObject]
    public class SoundData
    {
        public string Id { get; set; }
        public Vector3 Position { get; set; }
    }


    [JsonObject]
    public class Vector3
    {
        [JsonProperty("x")]
        public float X { get; set; }
        [JsonProperty("y")]
        public float Y { get; set; }
        [JsonProperty("z")]
        public float Z { get; set; }
    }
}
