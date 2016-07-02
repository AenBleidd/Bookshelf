using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class TypeList
  {
    public static List<Type> TypesList
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Types.OrderBy(x => x.Name).ToList();
        }
      }
    }
  }
}
