using System.ComponentModel.DataAnnotations.Schema;

namespace Bookshelf.DB
{
  public class Book
  {
    public int Id { get; set; }
    public Type Type { get; set; }
    public string NameOriginal { get; set; }
    public string Name { get; set; }
    public Series Series { get; set; }
    public Book NextInSeries { get; set; }
    public Author Author { get; set; }
    public int YearFirstPublished { get; set; }
    public int YearPublished { get; set; }
    public Country CountryOriginal { get; set; }
    public Country Country { get; set; }
    public Publisher PublisherOriginal { get; set; }
    public Publisher Publisher { get; set; }
    public Language LanguageOriginal { get; set; }
    public Language Language { get; set; }
    public string UID { get; set; } // ISBN or ISSN
    [Column(TypeName = "image")]
    public byte[] Image { get; set; }
  }
}
