using Newtonsoft.Json;
using System.Linq;
using SnipeSharp.Common;
using SnipeSharp.Exceptions;

namespace SnipeSharp.Endpoints.Models
{
    public class StatusLabel : CommonEndpointModel
    {
        public StatusLabel(string name)
        {
            this.Name = name;
            this.Type = name;
        }

        private string _type;

        [JsonProperty("type")]
        [RequestHeader("type", true)]
        public string Type
        {
            get
            {
                return _type;
            }

            set
            {
                // TODO: Move this logic somewhere else
                string[] validTypes = {"undeployable", "deployable", "pending", "archived", "in production", "ready to deploy" };
                if (validTypes.Contains(value.ToLower()))
                {
                    _type = value;
                } else
                {
                    throw new InvalidStatusLabelTypeException(
                        $"{value} Is an invalid status label.  Use {string.Join(", ", validTypes)}");
                }
            }
        }

        [JsonProperty("color")]
        [RequestHeader("color")]
        public string Color { get; set; }

        [JsonProperty("show_in_nav")]
        [RequestHeader("show_in_nav")]
        public bool ShowInNav { get; set; }

        [JsonProperty("assets_count")]
        public long? AssetsCount { get; set; }

        [JsonProperty("notes")]
        [RequestHeader("notes")]
        public string Notes { get; set; }

        [RequestHeader("deployable", true)]
        public bool Deployable { get; set; }

        [RequestHeader("pending", true)]
        public bool Pending { get; set; }

        [RequestHeader("archived", true)]
        public bool Archived { get; set; }
    }
}
