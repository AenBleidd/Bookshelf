using Bookshelf.DB;
using System.Collections.Generic;
using System.Linq;

namespace Bookshelf.Data
{
  public class LanguageList
  {
    public static List<Language> LanguagesLists
    {
      get
      {
        using (var db = new BookshelfDbContext())
        {
          return db.Languages.OrderBy(x => x.Name).ToList();
        }
      }
    }

    public static Language AddLanguage(Language language)
    {
      if (language == null) return null;
      using (var db = new BookshelfDbContext())
      {
        db.Languages.Add(language);
        db.SaveChanges();
        var id = db.Languages.Max(x => x.Id);
        return db.Languages.Where(x => x.Id == id).FirstOrDefault();
      }
    }
  }
}
