using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using WinUIEx;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;
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

        private void LaunchButton_Click(object sender, RoutedEventArgs e)
        {
            // https://docs.microsoft.com/en-us/windows/winui/api/microsoft.ui.xaml.window?view=winui-3.0

            DetailWindow window = new();
            window.SetIsMaximizable(false);
            window.SetIsResizable(false);
            window.SetWindowSize(360, 240);
            window.CenterOnScreen();
            window.Activate();

            Unloaded += (sender, e) => { window.Close(); };
        }

        private void RaiseButton_Click(object sender, RoutedEventArgs e)
        {
            Ioc.Default.GetService<IMessenger>().Send(new RaiseMessage());
        }
    }
}
