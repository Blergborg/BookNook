using System;
using System.Collections.Generic;
using System.Linq;
using BookNook.Models;

namespace BookNook.Repositories
{
  public class InMemBooksRepo : IBooksRepo
  {
    // Data
    // Fun new feature, can just write new() intead of new List<T>()
    private readonly List<Book> books = new()
    {
      new Book { Id = Guid.NewGuid(), Title = "Dune", Author = "Frank Herbert", Summary = "Sand and Worms", Price = 12 },
      new Book { Id = Guid.NewGuid(), Title = "Game of Thrones", Author = "George R.R. Martin", Summary = "Dragons and Disappointment", Price = 21 },
      new Book { Id = Guid.NewGuid(), Title = "One Fish Two Fish", Author = "Dr. Suess", Summary = "Red Fish Blue Fish", Price = 7 }
    };

    // Methods
    // GET all
    // NOTE: IEnumberable is a basic interface for returning a collection of objects
    public IEnumerable<Book> GetBooks()
    {
      return books;
    }

    // GET by Id
    public Book GetBook(Guid id)
    {
      // return only a matching book, or return null with ".SingleOrDefault()"
      return books.Where(book => book.Id == id).SingleOrDefault();
    }

    public void CreateBook(Book book)
    {
      books.Add(book);
    }

    public void UpdateBook(Book book)
    {
      // find index of match
      var index = books.FindIndex(existingBook => existingBook.Id == book.Id);
      // replace old book with new book
      books[index] = book;
    }

    public void DeleteBook(Guid id)
    {
      var index = books.FindIndex(existingBook => existingBook.Id == id);
      books.RemoveAt(index);
    }
  }
}