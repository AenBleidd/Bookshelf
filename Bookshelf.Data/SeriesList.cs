using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class SeriesList
  {
    public static List<Series> SeriesLists
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Series.OrderBy(x => x.Name).ToList();
        }
      }
    }

    public static Series AddSeries(Series series)
    {
      if (series == null) return null;
      using (var db = new BookshelfDbContext())
      {
        db.Series.Add(series);
        db.SaveChanges();
        var id = db.Series.Max(x => x.Id);
        return db.Series.Where(x => x.Id == id).FirstOrDefault();
      }
    }
  }
}
