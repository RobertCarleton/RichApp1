using System.Diagnostics.Contracts;
using System.Text.Json.Serialization;

namespace Rad301_2024_Week4_Lab1
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

        //[JsonConverter(typeof(JsonStringEnumConverter))]
        public Status TodoStatus { get; set; }
        public int Priority { get; set; }
    }
}
