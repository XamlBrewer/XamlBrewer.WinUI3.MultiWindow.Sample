using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;

namespace XamlBrewer.WinUI3.MultiWindow.Sample
{
    public sealed partial class Shell : Window
    {
        public Shell()
        {
            Title = "XAML Brewer WinUI 3 MultiWindow Sample";

            InitializeComponent();

            (Application.Current as App).EnsureSettings();
            ApplyTheme();
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            var settings = (Application.Current as App).Settings;
            settings.IsLightTheme = !settings.IsLightTheme;
            (Application.Current as App).SaveSettings();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();

            Ioc.Default.GetService<IMessenger>().Send(new ThemeChangedMessage(Root.ActualTheme));
        }

        private void ApplyTheme()
        {
            var settings = (Application.Current as App).Settings;
            Root.RequestedTheme = settings.IsLightTheme ? ElementTheme.Light : ElementTheme.Dark;
        }

        private void Root_ActualThemeChanged(FrameworkElement sender, object args)
        {
            // Theme change refinements (e.g. content dialogs and title bar).
        }
    }
}
