using System.Collections.Generic;
using System.Linq;

using Bookshelf.DB;

namespace Bookshelf.Data
{
  public class Authors
  {
    public static List<Author> AuthorList
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Authors.OrderBy(x => x.Name).ToList();
        }
      }
    }

    public static Author AddAuthor(Author author)
    {
      if (author == null) return null;
      using (var db = new BookshelfDbContext())
      {
        db.Authors.Add(author);
        db.SaveChanges();
        var id = db.Authors.Max(x => x.Id);
        return db.Authors.Where(x => x.Id == id).FirstOrDefault();
      }
    }
  }
}
