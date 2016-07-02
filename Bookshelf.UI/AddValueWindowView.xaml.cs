using System.Windows.Controls;
using System.Windows.Input;

namespace Bookshelf.UI
{
  /// <summary>
  /// Interaction logic for AddValueWindowView.xaml
  /// </summary>
  /// 
  public partial class AddValueWindowView : UserControl
  {
    public AddValueWindowView()
    {
      InitializeComponent();
      Keyboard.Focus(ValueTextBox);
      ValueTextBox.Focus();
    }
  }
}
