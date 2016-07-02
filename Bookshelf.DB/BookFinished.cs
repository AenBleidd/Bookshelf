namespace Bookshelf.DB
{
  public class BookFinished
  {
    public int Id { get; set; }
    public Book Book { get; set; }
    public User User { get; set; }
  }
}
