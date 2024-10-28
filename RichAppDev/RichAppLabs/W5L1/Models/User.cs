using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace W5L1.Models
{
    public enum Title
    {
        [Display(Name = "Mr.")]
        Mr,
        [Display(Name = "Ms.")]
        Ms,
        [Display(Name = "Mrs.")]
        Mrs,
        [Display(Name = "Master")]
        Master
    }
    public class User
    {
        public int ID { get; set; }
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string FName { get; set; }

        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z0-9""'\s-]*$")]
        [StringLength(20, MinimumLength = 4)]
        [Required]
        public string LName { get; set; }

        [Display(Name = "Martial Title")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [Required]
        public Title title { get; set; }

        [StringLength(2000, MinimumLength = 100)]
        [Required]
        public string Biography { get; set; }

        [Range(0, 200)]
        [Required]
        public int Age { get; set; }
    }
}
