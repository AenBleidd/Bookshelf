using Bookshelf.Utils;
using System.Windows;

namespace Bookshelf.UI
{
  /// <summary>
  /// Interaction logic for AddValueWindow.xaml
  /// </summary>
  public partial class AddValueWindow : Window
  {
    public AddValueWindow(string label)
    {
      InitializeComponent();

      if (DataContext != null)
      {
        var vm = DataContext as AddValueWindowViewModel;
        vm.Label = label;
        vm.OnOKButton = new RelayCommand(OKButton);
      }
    }
    public string GetValue()
    {
      if (DataContext != null)
      {
        var vm = DataContext as AddValueWindowViewModel;
        return vm.Value;
      }
      return null;
    }
    private void OKButton(object sender)
    {
      DialogResult = true;
    }
  }
}
