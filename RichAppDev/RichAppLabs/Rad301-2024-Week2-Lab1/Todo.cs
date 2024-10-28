using System.Diagnostics.Contracts;

namespace Rad301_2024_Week2_Lab1
{
    public class Todo
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsComplete { get; set; }
        public int Priority { get; set; }
    }
}
