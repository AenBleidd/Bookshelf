using System.Data.Entity;

namespace Bookshelf.DB
{
  public class BookshelfDbContext : DbContext
  {
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookOnShelf> BooksOnShelf { get; set; }
    public DbSet<BookFinished> BooksFinished { get; set; }
    public DbSet<BookPlannedToRead> BooksPlannedToRead { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Language> Languages { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Series> Series { get; set; }
    public DbSet<Type> Types { get; set; }
    public DbSet<User> Users { get; set; }

    public BookshelfDbContext()// : base("BookshelfDbContext")
    {
    }
  }
}
