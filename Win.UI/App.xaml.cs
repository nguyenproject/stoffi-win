using Windows.UI.Xaml;
using System.Threading.Tasks;
using Stoffi.Win.Logic.Services;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using Microsoft.Practices.Unity;
using Stoffi.Core.Services;
using Windows.ApplicationModel;

namespace Stoffi.Win
{
    /// Documentation on APIs used in this page:
    /// https://github.com/Windows-XAML/Template10/wiki

    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();
            SplashFactory = (e) => new Views.Splash(e);
            EnableAutoRestoreAfterTerminated = false;

            #region IoC
            var settingsStorage = new SettingsStorage();
            settingsStorage.LargeSettings.Add("NavigationState");
            Container.Instance.RegisterInstance<SettingsStorage>(settingsStorage);
            Container.Instance.RegisterType<ISettingsStorage, SettingsStorage>();
            Container.Instance.RegisterType<ISettingsService, Core.Services.SettingsService>();
            #endregion

            #region App settings
            var settings = Container.Instance.Resolve<ISettingsService>();
            var theme = settings.Read<ApplicationTheme>("AppTheme", ApplicationTheme.Dark).Result;
            RequestedTheme = theme;
            #endregion
        }

        public override async Task OnInitializeAsync(IActivatedEventArgs args)
        {
            if (Window.Current.Content as ModalDialog == null)
            {
                // create a new frame 
                var nav = NavigationServiceFactory(BackButton.Attach, ExistingContent.Include);
                // create modal root
                Window.Current.Content = new ModalDialog
                {
                    DisableBackButtonWhenModal = true,
                    Content = new Views.Shell(nav),
                    ModalContent = new Views.Busy(),
                };
            }
            await Task.CompletedTask;
        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            if (startKind == StartKind.Launch)
            {
                var settings = Container.Instance.Resolve<ISettingsService>();
                var navState = await settings.Read<string>("NavigationState", "");
                if (string.IsNullOrWhiteSpace(navState))
                    NavigationService.Navigate(typeof(Views.DashboardPage));
                else
                    NavigationService.NavigationState = navState;
            }
            await Task.CompletedTask;
        }

        public override Task OnSuspendingAsync(object s, SuspendingEventArgs e, bool prelaunchActivated)
        {
            var settings = Container.Instance.Resolve<ISettingsService>();
            settings.Write<string>("NavigationState", NavigationService.NavigationState);
            return base.OnSuspendingAsync(s, e, prelaunchActivated);
        }
    }
}

