using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.ViewModels
{
    public partial class HomePageViewModel : ObservableRecipient, IRecipient<AssetsChangedMessage>
    {
        [ObservableProperty]
        private int wealth;

        public HomePageViewModel()
        {
            Messenger.Register(this);
        }

        public void Receive(AssetsChangedMessage message)
        {
            Wealth += message.Value;
        }
    }
}
