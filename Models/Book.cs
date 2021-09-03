using System;

namespace BookNook.Models
{
  public record Book 
  {
    // init-only property, cannot change id after obj is made
    public Guid Id { get; init; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Summary { get; set; }

    public decimal Price { get; init; }
  }
}