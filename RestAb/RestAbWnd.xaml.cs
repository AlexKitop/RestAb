using System.Windows;
using System.Windows.Automation.Peers;

namespace RestAb
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class RestAbWnd : Window
  {
    public RestAbWnd()
    {
      DataContext = new RestAbViewModel();
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      RunButton.Command?.Execute(null);
    }
  }
}
