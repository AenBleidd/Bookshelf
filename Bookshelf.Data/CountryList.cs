using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class CountryList
  {
    public static List<Country> CountriesLists
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Countries.OrderBy(x => x.Name).ToList();
        }
      }
    }

    public static Country AddCountry(Country country)
    {
      if (country == null) return null;
      using (var db = new BookshelfDbContext())
      {
        db.Countries.Add(country);
        db.SaveChanges();
        var id = db.Countries.Max(x => x.Id);
        return db.Countries.Where(x => x.Id == id).FirstOrDefault();
      }
    }
  }
}
