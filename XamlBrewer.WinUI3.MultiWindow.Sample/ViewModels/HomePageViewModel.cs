using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.ViewModels
{
    public class HomePageViewModel : ObservableRecipient, IRecipient<AssetsChangedMessage>
    {
        public HomePageViewModel()
        {
            Messenger.Register(this);
        }

        public void Receive(AssetsChangedMessage message)
        {
            // throw new System.NotImplementedException();
        }
    }
}
