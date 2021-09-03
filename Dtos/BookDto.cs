using System;

namespace BookNook.Dtos
{
public record BookDto 
  {
    // init-only property, cannot change id after obj is made
    public Guid Id { get; init; }

    public string Title { get; set; }

    public string Author { get; set; }

    public string Summary { get; set; }

    public decimal Price { get; init; }
  }
}