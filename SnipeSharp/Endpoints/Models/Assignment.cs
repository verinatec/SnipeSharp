using Newtonsoft.Json;
using SnipeSharp.Common;
using System.Collections.Generic;

namespace SnipeSharp.Endpoints.Models
{
    public class Assignment : CommonEndpointModel
    {

        [JsonProperty("name")]
        [RequestHeader("name")]
        public new string Name { get; set; }

        [JsonProperty("type")]
        [RequestHeader("type")]
        public string Type { get; set; }

        /*
        [JsonProperty("first_name")]
        [RequestHeader("first_name")]
        public string Firstname { get; set; }

        [JsonProperty("last_name")]
        [RequestHeader("last_name")]
        public string Lastname { get; set; }
        */
    }
}
