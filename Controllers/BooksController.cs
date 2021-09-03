
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using BookNook.Models;
using BookNook.Repositories;
using BookNook.Dtos;

namespace BookNook.Controllers
{
  // Mark class as an ApiController
  [ApiController]
  // Declare route
  [Route("[controller]")]
  public class BooksController: ControllerBase
  {
    // storage var for instance of in-mem repo
    private readonly IBooksRepo repository;

    // constructor
    public BooksController(IBooksRepo repository)
    {
        this.repository = repository;
    }

    // GET /books
    [HttpGet]
    public IEnumerable<BookDto> GetBooks()
    {
      var books = repository.GetBooks().Select(book => book.AsDto());
      return books;
    }

    // GET /books/id
    [HttpGet("{id}")]
    public ActionResult<BookDto> GetBook(Guid id)
    {
      var book = repository.GetBook(id);

      if(book is null)
      {
        return NotFound();
      }

      return Ok(book.AsDto());
    }

    // POST /books
    [HttpPost]
    public ActionResult<BookDto> CreateBook(CreateBookDto bookDto)
    {
      Book book = new()
      {
        Id = Guid.NewGuid(),
        Title = bookDto.Title,
        Author = bookDto.Author,
        Summary = bookDto.Summary,
        Price = bookDto.Price
      };

      repository.CreateBook(book);

      // Convention is to return the item created and a header that specifies
      // where the you can get info about the created item.

      // 'CreatedAtAction()' method:
      // return nameof route where action can be used to reach item,
      // id of item created b/c that's need to reach it,
      // finally the item we created itself, but as DTO b/c we are sending it back to client.
      // NOTE: could also use 'CreatedAtRoute()' method.
      return CreatedAtAction(nameof(GetBook), new {id = book.Id}, book.AsDto());
    }
    // PUT /books/{id}
    // NOTE: convention w/ put is not to return anything w/ "NoContent()".
    [HttpPut("{id}")]
    public ActionResult UpdateBook(Guid id, UpdateBookDto bookDto)
    {
      // check if book exists
      var existing = repository.GetBook(id);
      if (existing is null)
      {
        return NotFound();
      }

      // use 'with' statement to make a copy of the existing book,
      // but with the specified modifications.
      Book updatedBook = existing with {
        Title = bookDto.Title,
        Author = bookDto.Author,
        Summary = bookDto.Summary,
        Price = bookDto.Price
      };

      repository.UpdateBook(updatedBook);

      return NoContent();
    }
    // DELETE /books/{id}
    // NOTE: like w/ PUT, convention is to return "NoContent()" after a delete.
    // NOTE2: Don't need a DTO for DELETE request, only needs and id to work.
    [HttpDelete("{id}")]
    public ActionResult DeleteBook(Guid id)
    {
      var existing = repository.GetBook(id);
      if (existing is null)
      {
        return NotFound();
      }

      repository.DeleteBook(id);
      return NoContent();
    }
  }
}