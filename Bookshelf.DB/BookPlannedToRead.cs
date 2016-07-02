namespace Bookshelf.DB
{
  public class BookPlannedToRead
  {
    public int Id { get; set; }
    public Book Book { get; set; }
    public User User { get; set; }
    public int Order { get; set; }
  }
}
