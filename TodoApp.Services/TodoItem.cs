using Newtonsoft.Json;

namespace TodoApp.Services
{
    public class TodoItem
    {
        public string Id { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Completed { get; set; }
    }
}
