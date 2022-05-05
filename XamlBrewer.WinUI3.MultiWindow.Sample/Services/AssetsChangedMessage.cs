using CommunityToolkit.Mvvm.Messaging.Messages;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.Services
{
    public class AssetsChangedMessage : ValueChangedMessage<int>
    {
        public AssetsChangedMessage(int value) : base(value)
        {
        }
    }
}
