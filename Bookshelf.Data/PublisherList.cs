using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class PublisherList
  {
    public static List<Publisher> PublishersLists
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Publishers.OrderBy(x => x.Name).ToList();
        }
      }
    }

    public static Publisher AddPublisher(Publisher publisher)
    {
      if (publisher == null) return null;
      using (var db = new BookshelfDbContext())
      {
        db.Publishers.Add(publisher);
        db.SaveChanges();
        var id = db.Publishers.Max(x => x.Id);
        return db.Publishers.Where(x => x.Id == id).FirstOrDefault();
      }
    }
  }
}
