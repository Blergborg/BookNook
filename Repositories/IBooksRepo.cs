using System;
using System.Collections.Generic;
using BookNook.Models;

namespace BookNook.Repositories
{
  public interface IBooksRepo
  {
    Book GetBook(Guid id);
    IEnumerable<Book> GetBooks();
    void CreateBook(Book book);

    void UpdateBook(Book book);
    void DeleteBook(Guid id);
  }
}