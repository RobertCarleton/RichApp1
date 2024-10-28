using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesBook.Models;

public class Book
{
    public int Id { get; set; }

    [StringLength(60, MinimumLength = 5)]
    [Required]
    public string Title { get; set; } = string.Empty;

    [StringLength(300, MinimumLength = 50)]
    [Required]
    public string Summary { get; set; } = string.Empty;

    [Display(Name = "Publication Date")]
    [DataType(DataType.Date)]
    public DateTime PublicationDate { get; set; }

    public int AuthorId { get; set; }

    public int PublisherId { get; set; }

    public string? CoverPage {  get; set; }
}