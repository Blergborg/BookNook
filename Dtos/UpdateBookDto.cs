using System.ComponentModel.DataAnnotations;

namespace BookNook.Dtos
{
  public class UpdateBookDto
  {
    [Required]
    public string Title { get; set; }

    [Required]
    public string Author { get; set; }

    [Required]
    public string Summary { get; set; }

    [Required]
    [Range(1, 5000)]
    public decimal Price { get; init; }
  }    
}