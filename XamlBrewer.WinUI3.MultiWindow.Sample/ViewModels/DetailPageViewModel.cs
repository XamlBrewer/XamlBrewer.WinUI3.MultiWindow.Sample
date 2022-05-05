﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.UI.Xaml;
using System;
using System.Timers;
using System.Windows.Input;
using XamlBrewer.WinUI3.MultiWindow.Sample.Services;

namespace XamlBrewer.WinUI3.MultiWindow.Sample.ViewModels
{
    public class DetailPageViewModel : ObservableRecipient, IRecipient<AssetsChangedMessage>
    {
        private bool isExcited;

        public DetailPageViewModel()
        {
            DiamondsFound = new RelayCommand(DiamondsFound_Executed);

            Messenger.Register(this);
        }

        public bool IsExcited
        {
            get => isExcited;
            set => SetProperty(ref isExcited, value);
        }

        public ICommand DiamondsFound { get; }


        public void Receive(AssetsChangedMessage message)
        {
            IsExcited = true;
            CoolDown();
        }

        private void DiamondsFound_Executed()
        {
            // Extensions:
            // https://docs.microsoft.com/en-us/dotnet/api/microsoft.toolkit.mvvm.messaging.imessengerextensions.send?view=win-comm-toolkit-dotnet-7.0

            Messenger.Unregister<AssetsChangedMessage>(this); // Don't react to own message.
            Messenger.Send(new AssetsChangedMessage(100));
            Messenger.Register(this);
        }

        private void CoolDown()
        {
            // Timer on the UI thread.
            var timer = new DispatcherTimer() { Interval = TimeSpan.FromSeconds(3) };
            timer.Tick += (s, e) => { IsExcited = false; timer.Stop(); };
            timer.Start();
        }
    }
}