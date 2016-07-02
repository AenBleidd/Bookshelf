using System;
using System.Windows;

namespace Bookshelf.UI
{
  /// <summary>
  /// Interaction logic for BookInfo.xaml
  /// </summary>
  public partial class BookInfoWindow : Window
  {
    public BookInfoWindow()
    {
      InitializeComponent();
      if (DataContext != null)
      {
        var vm = DataContext as BookInfoViewModel;
        vm.CloseAction = new Action(() => Close());
      }      
    }
  }
}
