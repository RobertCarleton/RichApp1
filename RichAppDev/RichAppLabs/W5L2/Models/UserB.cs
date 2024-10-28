using System.ComponentModel.DataAnnotations;

namespace W5L2.Models
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
    public class UserB
    {
        [Display(Name = "Martial Title")]
        public Title title { get; set; }
        public string Biography { get; set; }
        [Key]
        public int UserID { get; set; }
        public UserA UserA { get; set; }
    }
}
