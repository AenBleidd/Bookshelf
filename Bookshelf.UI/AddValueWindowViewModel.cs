using Bookshelf.Utils;
using System.Windows.Input;

namespace Bookshelf.UI
{
  public class AddValueWindowViewModel : NotifyPropertyChanged
  {
    private string label;
    private string value;

    public string Label
    {
      get { return label; }
      set { label = value; }
    }
    public string Value
    {
      get { return value; }
      set { this.value = value; }
    }
    public ICommand OnOKButton
    {
      get;
      set;
    }
  }
}
