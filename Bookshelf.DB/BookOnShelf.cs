namespace Bookshelf.DB
{
  public class BookOnShelf
  {
    public int Id { get; set; }
    public Book Book { get; set; }
    public Location Location { get; set; }
    public User User { get; set; }
  }
}
