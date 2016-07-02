using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

using Bookshelf.DB;
using Bookshelf.Utils;

namespace Bookshelf.Data
{
  public class BookInfo : NotifyPropertyChanged
  {
    private Book Book = new Book();

    public BookInfo (int? BookId = null)
    {
      if (BookId != null)
      {
        using (var db = new BookshelfDbContext())
        {
          Book = db.Books.Where(x => x.Id == BookId).FirstOrDefault();
        }
      }
    }

    public bool Save()
    {
      if (Book.Name == string.Empty || Book.Author == null)
        return false;
      using (var db = new BookshelfDbContext())
      {
        db.Books.Add(Book);
        db.SaveChanges();
      }
      return true;
    }

    public string UID
    {
      get { return Book.UID; }
      set
      {
        if (Book.UID != value)
          Book.UID = value;
      }
    }
    public Image Image
    {
      get
      {
        if (Book.Image == null)
          return null;
        var ms = new MemoryStream(Book.Image);
        return Image.FromStream(ms);
      }
      set
      {
        var ms = new MemoryStream();
        Image.Save(ms, ImageFormat.Jpeg);
        Book.Image = ms.ToArray();
      }
    }
    public string Name
    {
      get { return Book.Name; }
      set
      {
        if (Book.Name != value)
          Book.Name = value;
      }
    }
    public string OriginalName
    {
      get { return Book.NameOriginal; }
      set
      {
        if (Book.NameOriginal != value)
          Book.NameOriginal = value;
      }
    }
    public Author Author
    {
      get { return Book.Author; }
      set
      {
        if (Book.Author != value)
          Book.Author = value;
      }
    }
    public Series Series
    {
      get { return Book.Series; }
      set
      {
        if (Book.Series != value)
          Book.Series = value;
      }
    }
    public Book NextBook
    {
      get { return Book.NextInSeries; }
      set
      {
        if (Book.NextInSeries != value)
          Book.NextInSeries = value;
      }
    }
    public Type Type
    {
      get { return Book.Type; }
      set
      {
        if (Book.Type != value)
          Book.Type = value;
      }
    }
    public int YearPublished
    {
      get { return Book.YearPublished; }
      set
      {
        if (Book.YearPublished != value)
          Book.YearPublished = value;
      }
    }
    public int YearFirstPublished
    {
      get { return Book.YearFirstPublished; }
      set
      {
        if (Book.YearFirstPublished != value)
          Book.YearFirstPublished = value;
      }
    }
    public Language Language
    {
      get { return Book.Language; }
      set
      {
        if (Book.Language != value)
          Book.Language = value;
      }
    }
    public Language LanguageOriginal
    {
      get { return Book.LanguageOriginal; }
      set
      {
        if (Book.LanguageOriginal != value)
          Book.LanguageOriginal = value;
      }
    }
    public Country Country
    {
      get { return Book.Country; }
      set
      {
        if (Book.Country != value)
          Book.Country = value;
      }
    }
    public Country CountryOriginal
    {
      get { return Book.CountryOriginal; }
      set
      {
        if (Book.CountryOriginal != value)
          Book.CountryOriginal = value;
      }
    }
    public Publisher Publisher
    {
      get { return Book.Publisher; }
      set
      {
        if (Book.Publisher != value)
          Book.Publisher = value;
      }
    }
    public Publisher PublisherOriginal
    {
      get { return Book.PublisherOriginal; }
      set
      {
        if (Book.PublisherOriginal != value)
          Book.PublisherOriginal = value;
      }
    }
  }
}
