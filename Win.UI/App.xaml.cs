using Windows.UI.Xaml;
using System.Threading.Tasks;
using Stoffi.Win.Logic.Services;
using Windows.ApplicationModel.Activation;
using Template10.Controls;
using Template10.Common;
using Template10.Utils;
using Microsoft.Practices.Unity;
using Stoffi.Core.Services;

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

            #region IoC
            Container.Instance.RegisterInstance<SettingsStorage>(new SettingsStorage());
            Container.Instance.RegisterType<ISettingsStorage, SettingsStorage>();
            Container.Instance.RegisterType<ISettingsService, Core.Services.SettingsService>();
            #endregion

            #region App settings
            var settings = Container.Instance.Resolve<ISettingsService>();
            var theme = settings.Read<ApplicationTheme>("theme", ApplicationTheme.Dark);
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
            // long-running startup tasks go here

            NavigationService.Navigate(typeof(Views.DashboardPage));
            await Task.CompletedTask;
        }
    }
}

