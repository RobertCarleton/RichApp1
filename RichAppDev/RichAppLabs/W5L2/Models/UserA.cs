using System.ComponentModel.DataAnnotations;

namespace W5L2.Models
{
    public class UserA
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "First Name")]
        public string FName { get; set; }
        [Display(Name = "Last Name")]
        public string LName { get; set; }
        public UserB UserB { get; set; }
        public int Age { get; set; }
    }
}
