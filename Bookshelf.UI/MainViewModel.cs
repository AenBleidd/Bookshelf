using System.Windows.Input;
using Bookshelf.Utils;
using System;

namespace Bookshelf.UI
{
  public class MainViewModel : NotifyPropertyChanged
  {
    public MainViewModel()
    {
      OnBookAdd = new RelayCommand(BookAdd);
    }

    public ICommand OnBookAdd
    {
      get;
      private set;
    }

    private void BookAdd(object sender)
    {
      var BookInfo = new BookInfoWindow();
      if (BookInfo.ShowDialog() == true)
      {
        throw new NotImplementedException();
      }
    }
  }
}
