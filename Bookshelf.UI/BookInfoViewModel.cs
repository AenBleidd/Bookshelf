using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows;

using Bookshelf.DB;
using Bookshelf.Data;
using Bookshelf.Utils;
using System.Text.RegularExpressions;

namespace Bookshelf.UI
{
  public class BookInfoViewModel : NotifyPropertyChanged
  {
    const string OKButtonText = "OK";
    const string SaveButtonText = "Save";
    const string CancelButtonText = "Cancel";
    const string LoadButtonText = "Load image";
    const string DeleteButtonText = "Delete image";
    const string UIdLabelText = "ISBN/ISSN";
    const string NameLabelText = "Title";
    const string OriginalNameLabelText = "Original Title";
    const string AuthorLabelText = "Author";
    const string AddNewAuthorLabelText = "Add new author";
    const string SeriesLabelText = "Serie";
    const string AddNewSeriesLabelText = "Add new serie";
    const string NextBookInSeriesLabelText = "Next Book";
    const string TypeLabelText = "Type";
    const string AddNewTypeLabelText = "Add new type";
    const string PublishedLabelText = "Published";
    const string FirstPublishedLabelText = "First Published";
    const string LanguageLabelText = "Language";
    const string LanguageOriginalLabelText = "Original Language";
    const string AddNewLanguageLabelText = "Add new language";
    const string CountryLabelText = "Country";
    const string CountryOriginalLabelText = "Original Country";
    const string AddNewCountryLabelText = "Add new country";
    const string PublisherLabelText = "Publisher";
    const string PublisherOriginalLabelText = "Original Publisher";
    const string AddNewPublisherLabelText = "Add new publisher";

    private int? bookId = null;
    BookInfo BookInfo = new BookInfo();

    public Action CloseAction { get; set; }

    public string OKButtonContent
    {
      get { return SaveButtonText; }
    }
    public string CancelButtonContent
    {
      get { return CancelButtonText; }
    }
    public string LoadButtonContent
    {
      get { return LoadButtonText; }
    }
    public string DeleteButtonContent
    {
      get { return DeleteButtonText; }
    }
    public string UIdLabelContent
    {
      get { return UIdLabelText; }
    }
    public string NameLabelContent
    {
      get { return NameLabelText; }
    }
    public string OriginalNameLabelContent
    {
      get { return OriginalNameLabelText; }
    }
    public string AuthorLabelContent
    {
      get { return AuthorLabelText; }
    }
    public string SeriesLabelContent
    {
      get { return SeriesLabelText; }
    }
    public string NextBookInSeriesLabelContent
    {
      get { return NextBookInSeriesLabelText; }
    }
    public string TypeLabelContent
    {
      get { return TypeLabelText; }
    }
    public string PublishedLabelContent
    {
      get { return PublishedLabelText; }
    }
    public string FirstPublishedLabelContent
    {
      get { return FirstPublishedLabelText; }
    }
    public string LanguageLabelContent
    {
      get { return LanguageLabelText; }
    }
    public string LanguageOriginalLabelContent
    {
      get { return LanguageOriginalLabelText; }
    }
    public string CountryLabelContent
    {
      get { return CountryLabelText; }
    }
    public string CountryOriginalLabelContent
    {
      get { return CountryOriginalLabelText; }
    }
    public string PublisherLabelContent
    {
      get { return PublisherLabelText; }
    }
    public string PublisherOriginalLabelContent
    {
      get { return PublisherOriginalLabelText; }
    }

    public ICommand OnOKButton
    {
      get { return new RelayCommand(OKButton); }
    }
    private void OKButton(object sender)
    {
      if (BookInfo != null && BookInfo.Save())
        CloseAction();
      else
        MessageBox.Show("Book Title and Book Author should be defined", "Error save book", MessageBoxButton.OK, MessageBoxImage.Error);
    }
    public ICommand OnCancelButton
    {
      get { return new RelayCommand(CancelButton); }
    }
    private void CancelButton(object sender)
    {
      CloseAction();
    }
    public ICommand OnLoadButton
    {
      get { return new RelayCommand(LoadButton); }
    }
    private void LoadButton(object sender)
    {
      throw new NotImplementedException();
    }
    public ICommand OnDeleteButton
    {
      get { return new RelayCommand(DeleteButton); }
    }
    private void DeleteButton(object sender)
    {
      throw new NotImplementedException();
    }
    public ICommand OnAddAuthor
    {
      get { return new RelayCommand(AddAuthor); }
    }
    private void AddAuthor(object sender)
    {
      var dlg = new AddValueWindow(AddNewAuthorLabelText);
      if (dlg.ShowDialog() == false) return;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return;
      if (!AuthorList.Where(x => x.Name == value).Any())
      {
        var author = new Author();
        author.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Authors.Add(author);
          db.SaveChanges();
        }
        OnPropertyChanged("AuthorList");
      }
      var tAuthor = AuthorList.Where(x => x.Name == value).First();
      if (tAuthor != null)
        AuthorID = tAuthor.Id;
    }
    public ICommand OnAddSeries
    {
      get { return new RelayCommand(AddSeries); }
    }
    private void AddSeries(object sedner)
    {
      var dlg = new AddValueWindow(AddNewSeriesLabelText);
      if (dlg.ShowDialog() == false) return;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return;
      if (!SeriesList.Where(x => x.Name == value).Any())
      {
        var series = new Series();
        series.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Series.Add(series);
          db.SaveChanges();
        }
        OnPropertyChanged("SeriesList");
      }
      var tSeries = SeriesList.Where(x => x.Name == value).First();
      if (tSeries != null)
        SeriesID = tSeries.Id;
    }
    public ICommand OnSearchByUid
    {
      get { return new RelayCommand(SearchByUid); }
    }
    private void SearchByUid(object sender)
    {
      throw new NotImplementedException();
    }
    public ICommand OnAddType
    {
      get { return new RelayCommand(AddType); }
    }
    private void AddType(object sender)
    {
      var dlg = new AddValueWindow(AddNewTypeLabelText);
      if (dlg.ShowDialog() == false) return;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return;
      if (!TypeList.Where(x => x.Name == value).Any())
      {
        var type = new DB.Type();
        type.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Types.Add(type);
          db.SaveChanges();
        }
        OnPropertyChanged("TypeList");
      }
      var tType = TypeList.Where(x => x.Name == value).First();
      if (tType != null)
        TypeID = tType.Id;
    }
    public ICommand OnAddLanguage
    {
      get { return new RelayCommand(AddLanguage); }
    }
    private Language AddLanguageCommon()
    {
      var dlg = new AddValueWindow(AddNewLanguageLabelText);
      if (dlg.ShowDialog() == false) return null;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return null;
      if (!LanguageList.Where(x => x.Name == value).Any())
      {
        var language = new Language();
        language.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Languages.Add(language);
          db.SaveChanges();
        }
        OnPropertyChanged("LanguageList");
      }
      return LanguageList.Where(x => x.Name == value).First();
    }
    private void AddLanguage(object sender)
    {
      var tlanguage = AddLanguageCommon();
      if (tlanguage != null)
        LanguageID = tlanguage.Id;
    }
    public ICommand OnAddLanguageOriginal
    {
      get { return new RelayCommand(AddLanguageOriginal); }
    }
    private void AddLanguageOriginal(object sender)
    {
      var tlanguage = AddLanguageCommon();
      if (tlanguage != null)
        LanguageOriginalID = tlanguage.Id;
    }
    private Country AddCountryCommon()
    {
      var dlg = new AddValueWindow(AddNewCountryLabelText);
      if (dlg.ShowDialog() == false) return null;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return null;
      if (!CountryList.Where(x => x.Name == value).Any())
      {
        var country = new Country();
        country.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Countries.Add(country);
          db.SaveChanges();
        }
        OnPropertyChanged("CountryList");
      }
      return CountryList.Where(x => x.Name == value).First();
    }
    public ICommand OnAddCountry
    {
      get { return new RelayCommand(AddCountry); }
    }
    private void AddCountry(object sender)
    {
      var tCountry = AddCountryCommon();
      if (tCountry != null)
        CountryID = tCountry.Id;
    }
    public ICommand OnAddCountryOriginal
    {
      get { return new RelayCommand(AddCountryOriginal); }
    }
    private void AddCountryOriginal(object sender)
    {
      var tCountry = AddCountryCommon();
      if (tCountry != null)
        CountryOriginalID = tCountry.Id;
    }
    private Publisher AddPublisherCommon()
    {
      var dlg = new AddValueWindow(AddNewPublisherLabelText);
      if (dlg.ShowDialog() == false) return null;
      var value = dlg.GetValue();
      if (value == null || value == string.Empty) return null;
      if (!PublisherList.Where(x => x.Name == value).Any())
      {
        var Publisher = new Publisher();
        Publisher.Name = value;
        using (var db = new BookshelfDbContext())
        {
          db.Publishers.Add(Publisher);
          db.SaveChanges();
        }
        OnPropertyChanged("PublisherList");
      }
      return PublisherList.Where(x => x.Name == value).First();
    }
    public ICommand OnAddPublisher
    {
      get { return new RelayCommand(AddPublisher); }
    }
    private void AddPublisher(object sender)
    {
      var tPublisher = AddPublisherCommon();
      if (tPublisher != null)
        PublisherID = tPublisher.Id;
    }
    public ICommand OnAddPublisherOriginal
    {
      get { return new RelayCommand(AddPublisherOriginal); }
    }
    private void AddPublisherOriginal(object sender)
    {
      var tPublisher = AddPublisherCommon();
      if (tPublisher != null)
        PublisherOriginalID = tPublisher.Id;
    }

    public int? BookId
    {
      get { return bookId; }
      set
      {
        if (value == bookId || bookId != null) return;
        bookId = value;
        BookInfo = new BookInfo(bookId);
      }
    }
    public string UId
    {
      get { return ISBNToString(BookInfo.UID); }
      set
      {
        if (ISBNToString(BookInfo.UID) != value)
          BookInfo.UID = StringToISBN(BookInfo.UID, value);
      }
    }
    public ImageSource Image
    {
      get
      {
        if (BookInfo.Image != null)
        {
          var converter = new ImageSourceConverter();
          return converter.ConvertFrom(BookInfo.Image) as ImageSource;
        }
        else
        {
          var img = new BitmapImage();
          img.BeginInit();
          img.UriSource = new Uri("pack://application:,,,/Bookshelf.UI;component/noimgavailable.jpg");
          img.EndInit();
          return img;
        }
      }
    }
    public string Name
    {
      get { return BookInfo.Name; }
      set
      {
        if (BookInfo.Name != value)
          BookInfo.Name = value;
      }
    }
    public string OriginalName
    {
      get { return BookInfo.OriginalName; }
      set
      {
        if (BookInfo.OriginalName != value)
          BookInfo.OriginalName = value;
      }
    }
    public List<Author> AuthorList
    {
      get { return Authors.AuthorList; }
    }
    public int? AuthorID
    {
      get
      {
        if (BookInfo.Author != null)
          return BookInfo.Author.Id;
        return null;
      }
      set
      {
        if (BookInfo.Author == null || BookInfo.Author.Id != value)
        {
          BookInfo.Author = AuthorList.Where(x => x.Id == value).First();
          OnPropertyChanged("AuthorID");
        }
      }
    }
    public List<Series> SeriesList
    {
      get { return Data.SeriesList.SeriesLists; }
    }
    public int? SeriesID
    {
      get
      {
        if (BookInfo.Series != null)
          return BookInfo.Series.Id;
        return null;
      }
      set
      {
        if (BookInfo.Series == null || BookInfo.Series.Id != value)
        {
          BookInfo.Series = SeriesList.Where(x => x.Id == value).First();
          OnPropertyChanged("SeriesID");
        }
      }
    }
    public List<Book> BooksListBySeries
    {
      get
      {
        if (SeriesID == null)
          return null;
        var series = SeriesList.Where(x => x.Id == SeriesID).First();
        if (BookId == null)
          return BookList.BooksListBySeries(series);
        else
        {
          var book = BookList.BooksList.Where(x => x.Id == BookId).First();
          return BookList.BooksListBySeries(series, book);
        }
      }
    }
    public int? NextBookID
    {
      get
      {
        if (BookInfo.NextBook != null)
          return BookInfo.NextBook.Id;
        return null;
      }
      set
      {
        if (BookInfo.NextBook == null || BookInfo.NextBook.Id != value)
        {
          BookInfo.NextBook = BooksListBySeries.Where(x => x.Id == value).First();
          OnPropertyChanged("NextBookID");
        }
      }
    }
    public List<DB.Type> TypeList
    {
      get { return Data.TypeList.TypesList; }
    }
    public int? TypeID
    {
      get
      {
        if (BookInfo.Type != null)
          return BookInfo.Type.Id;
        return null;
      }
      set
      {
        if (BookInfo.Type == null || BookInfo.Type.Id != value)
        {
          BookInfo.Type = TypeList.Where(x => x.Id == value).First();
          OnPropertyChanged("TypeID");
        }
      }
    }
    public string Published
    {
      get { return Convert.ToString(BookInfo.YearPublished); }
      set
      {
        var year = ValidateYear(value);
        if (year != null && BookInfo.YearPublished != year)
          BookInfo.YearPublished = year.Value;
      }
    }
    public string FirstPublished
    {
      get { return Convert.ToString(BookInfo.YearFirstPublished); }
      set
      {
        var year = ValidateYear(value);
        if (year != null && BookInfo.YearFirstPublished != year)
          BookInfo.YearFirstPublished = year.Value;
      }
    }
    public List<Language> LanguageList
    {
      get { return Data.LanguageList.LanguagesLists; }
    }
    public int? LanguageID
    {
      get
      {
        if (BookInfo.Language != null)
          return BookInfo.Language.Id;
        return null;
      }
      set
      {
        if (BookInfo.Language == null || BookInfo.Language.Id != value)
        {
          BookInfo.Language = LanguageList.Where(x => x.Id == value).First();
          OnPropertyChanged("LanguageID");
        }
      }
    }
    public int? LanguageOriginalID
    {
      get
      {
        if (BookInfo.LanguageOriginal != null)
          return BookInfo.LanguageOriginal.Id;
        return null;
      }
      set
      {
        if (BookInfo.LanguageOriginal == null || BookInfo.LanguageOriginal.Id != value)
        {
          BookInfo.LanguageOriginal = LanguageList.Where(x => x.Id == value).First();
          OnPropertyChanged("LanguageOriginalID");
        }
      }
    }
    public List<Country> CountryList
    {
      get { return Data.CountryList.CountriesLists; }
    }
    public int? CountryID
    {
      get
      {
        if (BookInfo.Country != null)
          return BookInfo.Country.Id;
        return null;
      }
      set
      {
        if (BookInfo.Country == null || BookInfo.Country.Id != value)
        {
          BookInfo.Country = CountryList.Where(x => x.Id == value).First();
          OnPropertyChanged("CountryID");
        }
      }
    }
    public int? CountryOriginalID
    {
      get
      {
        if (BookInfo.CountryOriginal != null)
          return BookInfo.CountryOriginal.Id;
        return null;
      }
      set
      {
        if (BookInfo.CountryOriginal == null || BookInfo.CountryOriginal.Id != value)
        {
          BookInfo.CountryOriginal = CountryList.Where(x => x.Id == value).First();
          OnPropertyChanged("CountryOriginalID");
        }
      }
    }
    public List<Publisher> PublisherList
    {
      get { return Data.PublisherList.PublishersLists; }
    }
    public int? PublisherID
    {
      get
      {
        if (BookInfo.Publisher != null)
          return BookInfo.Publisher.Id;
        return null;
      }
      set
      {
        if (BookInfo.Publisher == null || BookInfo.Publisher.Id != value)
        {
          BookInfo.Publisher = PublisherList.Where(x => x.Id == value).First();
          OnPropertyChanged("PublisherID");
        }
      }
    }
    public int? PublisherOriginalID
    {
      get
      {
        if (BookInfo.PublisherOriginal != null)
          return BookInfo.PublisherOriginal.Id;
        return null;
      }
      set
      {
        if (BookInfo.PublisherOriginal == null || BookInfo.PublisherOriginal.Id != value)
        {
          BookInfo.PublisherOriginal = PublisherList.Where(x => x.Id == value).First();
          OnPropertyChanged("PublisherOriginalID");
        }
      }
    }

    private string StringToISBN(string old, string value)
    {
      if (value == string.Empty)
        return null;
      var regex = new Regex(@"^[0-9\-]+$");
      if (!regex.IsMatch(value))
        return old;
      return value;
    }
    private string ISBNToString(string value)
    {
      return value;
    }
    private int? ValidateYear(string year)
    {
      if (year == null || year == string.Empty)
        return null;
      try
      {
        var y = Convert.ToInt32(year);
        if (y <= 0 || y > DateTime.Now.Year)
          return null;
        return y;
      }
      catch
      {
        return null;
      }
    }
  }
}
