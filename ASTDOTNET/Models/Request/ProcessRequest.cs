using System.Text.Json.Serialization;

namespace ASTDOTNET.Models.Request
{
    public class ProcessRequest
    {
        [JsonIgnore]
        public string Input { get; set; } = "string,string,1,2,1,3,5,4,2,4";
    }

}
