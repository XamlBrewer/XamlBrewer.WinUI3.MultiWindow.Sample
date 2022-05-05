using CommunityToolkit.Mvvm.Messaging.Messages;
using Microsoft.UI.Xaml;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.Services
{
    public class ThemeChangedMessage : ValueChangedMessage<ElementTheme>
    {
        public ThemeChangedMessage(ElementTheme value) : base(value)
        {
        }
    }
}
