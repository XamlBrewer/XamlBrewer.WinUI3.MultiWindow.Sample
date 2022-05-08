using CommunityToolkit.Mvvm.DependencyInjection;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Media.Imaging;
using System;
using WinUIEx;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;
using XamlBrewer.WinUI3.MultiWindow.Sample.ViewModels;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.Views
{
    public sealed partial class DetailWindow : Window
    {
        public DetailWindow()
        {
            Title = "Detail Window";

            InitializeComponent();
            Root.ActualThemeChanged += Root_ActualThemeChanged;
            ApplyTheme();

            var messenger = Ioc.Default.GetService<IMessenger>();

            messenger.Register<ThemeChangedMessage>(this, (r,m) =>
            {
                Root.RequestedTheme = m.Value;
            });

            messenger.Register<RaiseMessage>(this, (r, m) =>
            {
                this.SetForegroundWindow();
            });

            // Don't forget!
            Closed += (sender, e) => { messenger.UnregisterAll(this); };

            var i = new Random();
            BackgroundImage.Source = new BitmapImage(new Uri($"ms-appx:///assets/{i.Next(1,5)}.jpg"));
        }

        private DetailPageViewModel ViewModel => Page.DataContext as DetailPageViewModel;

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
