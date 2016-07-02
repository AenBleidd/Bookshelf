using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class BookList
  {
    public static List<Book> BooksList
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Books.OrderBy(x => x.Name).ToList();
        }
      }
    }
    public static List<Book> BooksListByAuthor(Author author)
    {
      using (var db = new BookshelfDbContext())
      {
        return db.Books
          .Where(x => x.Author.Id == author.Id)
          .OrderBy(x => x.Name)
          .ToList();
      }
    }
    public static List<Book> BooksListBySeries(Series series, Book current = null)
    {
      using (var db = new BookshelfDbContext())
      {
        return db.Books
          .Where(x => x.Series.Id == series.Id && (current == null || x.Id != current.Id))
          .OrderBy(x => x.Name)
          .ToList();
      }
    }
  }
}
