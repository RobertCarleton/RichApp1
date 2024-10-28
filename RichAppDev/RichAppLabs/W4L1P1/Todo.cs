using System.Text.Json.Serialization;

namespace W4L1P1
{
    public enum Status
    {
        NotStarted,
        Begun,
        InProgress,
        Complete
    }
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Status TodoStatus { get; set; }
        public int Priority { get; set; }
    }
}
