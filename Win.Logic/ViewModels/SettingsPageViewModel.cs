using System;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml;
using Microsoft.Practices.Unity;
using Stoffi.Core.Services;
using Template10.Utils;

namespace Stoffi.Win.Logic.ViewModels
{
    public class SettingsPageViewModel : ViewModelBase
    {
        public SettingsPartViewModel SettingsPartViewModel { get; } = new SettingsPartViewModel();
        public AboutPartViewModel AboutPartViewModel { get; } = new AboutPartViewModel();
    }

    public class SettingsPartViewModel : ViewModelBase
    {
        ISettingsService settings;

        public SettingsPartViewModel()
        {
            settings = Container.Instance.Resolve<ISettingsService>();
        }

        /// <summary>
        /// Gets or sets whether or not to use the Light theme.
        /// </summary>
        public bool UseLightThemeButton
        {
            get
            {
                var theme = settings.Read<ApplicationTheme>("AppTheme", ApplicationTheme.Dark).Result;
                return theme.Equals(ApplicationTheme.Light);
            }
            set
            {
                ApplicationTheme theme = value ? ApplicationTheme.Light : ApplicationTheme.Dark;
                settings.Write<ApplicationTheme>("AppTheme", theme).Wait();
                (Window.Current.Content as FrameworkElement).RequestedTheme = theme.ToElementTheme();
                base.RaisePropertyChanged();
            }
        }

        private string _BusyText = "Please wait...";
        public string BusyText
        {
            get { return _BusyText; }
            set
            {
                Set(ref _BusyText, value);
                showBusyCommand.RaiseCanExecuteChanged();
            }
        }

        DelegateCommand showBusyCommand;
        public DelegateCommand ShowBusyCommand
            => showBusyCommand ?? (showBusyCommand = new DelegateCommand(async () =>
            {
                //Views.Busy.SetBusy(true, _BusyText);
                await Task.Delay(5000);
                //Views.Busy.SetBusy(false);
            }, () => !string.IsNullOrEmpty(BusyText)));
    }

    public class AboutPartViewModel : ViewModelBase
    {
        public Uri Logo => Windows.ApplicationModel.Package.Current.Logo;

        public string DisplayName => Windows.ApplicationModel.Package.Current.DisplayName;

        public string Publisher => Windows.ApplicationModel.Package.Current.PublisherDisplayName;

        public string Version
        {
            get
            {
                var v = Windows.ApplicationModel.Package.Current.Id.Version;
                return $"{v.Major}.{v.Minor}.{v.Build}.{v.Revision}";
            }
        }

        public Uri RateMe => new Uri("http://aka.ms/template10");
    }
}

