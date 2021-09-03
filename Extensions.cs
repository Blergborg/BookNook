using BookNook.Dtos;
using BookNook.Models;

namespace BookNook
{
    public static class Extensions{
      public static BookDto AsDto(this Book book)
      {
        return new BookDto
        {
          Id = book.Id,
          Title = book.Title,
          Author = book.Author,
          Summary = book.Summary,
          Price = book.Price
        };
      }
    }
}