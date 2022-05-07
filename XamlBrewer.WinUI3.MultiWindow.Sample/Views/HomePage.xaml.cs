using Microsoft.UI.Dispatching;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Threading;
using WinUIEx;
using XamlBrewer.WinUI3.MultiWindow.Sample.ViewModels;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.Views
{
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        private HomePageViewModel ViewModel => DataContext as HomePageViewModel;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // https://docs.microsoft.com/en-us/windows/winui/api/microsoft.ui.xaml.window?view=winui-3.0

            DetailWindow window = new();
            window.SetIsMaximizable(false);
            window.SetIsResizable(false);
            window.SetWindowSize(450, 300);
            window.CenterOnScreen();
            window.Activate();

            Unloaded += (sender, e) => { window.Close(); };
        }
    }
}
