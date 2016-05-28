using Stoffi.Core.Services;
using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Template10.Services.SettingsService;

namespace Stoffi.Win.Logic.Services
{
    /// <summary>
    /// Stores settings in the Windows default setting storage by
    /// leveraging the Template10 helper.
    /// 
    /// Implements three strategies for storing the settings:
    /// - Local: Settings are stored locally on the device
    /// - Temp: Settings are stored in temporary storage
    /// - Roam: Settings are shared between devices
    /// </summary>
    public class SettingsStorage : ISettingsStorage
    {
        ISettingsHelper helper;

        /// <summary>
        /// The strategy to use for storing settings.
        /// </summary>
        public SettingsStrategies Strategy { get; set; }

        public SettingsStorage(SettingsStrategies strategy = SettingsStrategies.Roam)
        {
            helper = new SettingsHelper();
            Strategy = strategy;
        }

        /// <summary>
        /// Check whether a given setting exists.
        /// </summary>
        /// <param name="name">The name of the record</param>
        /// <returns>True if the setting exists, false otherwise</returns>
        public bool Exists(string name)
        {
            helper.Exists(name, Strategy);
            throw new NotImplementedException();
        }

        /// <summary>
        /// Read the value of a given setting.
        /// </summary>
        /// <typeparam name="T">The type of the setting</typeparam>
        /// <param name="name">The name of the setting</param>
        /// <param name="otherwise">The default value to return if the setting is not found</param>
        /// <returns>The setting if found, `otherwise` if not</returns>
        public T Read<T>(string name, T otherwise)
        {
            return helper.Read<T>(name, otherwise, Strategy);
        }

        /// <summary>
        /// Remove a given setting.
        /// </summary>
        /// <param name="name">The name of the setting</param>
        public void Remove(string name)
        {
            helper.Remove(name, Strategy);
        }

        /// <summary>
        /// Save a setting.
        /// </summary>
        /// <typeparam name="T">The type of the setting</typeparam>
        /// <param name="name">The name of the setting</param>
        /// <param name="value">The value of the setting</param>
        public void Write<T>(string name, T value)
        {
            helper.Write<T>(name, value, Strategy);
        }
    }

    public class SettingsService
    {
        public static SettingsService Instance { get; }
        static SettingsService()
        {
            // implement singleton pattern
            Instance = Instance ?? new SettingsService();
        }

        Template10.Services.SettingsService.ISettingsHelper helper;
        private SettingsService()
        {
            helper = new Template10.Services.SettingsService.SettingsHelper();
        }

        public bool UseShellBackButton
        {
            get { return helper.Read<bool>(nameof(UseShellBackButton), true); }
            set
            {
                helper.Write(nameof(UseShellBackButton), value);
                BootStrapper.Current.NavigationService.Dispatcher.Dispatch(() =>
                {
                    BootStrapper.Current.ShowShellBackButton = value;
                    BootStrapper.Current.UpdateShellBackButton();
                    BootStrapper.Current.NavigationService.Refresh();
                });
            }
        }

        public ApplicationTheme AppTheme
        {
            get
            {
                var theme = ApplicationTheme.Dark;
                var value = helper.Read<string>(nameof(AppTheme), theme.ToString());
                return Enum.TryParse<ApplicationTheme>(value, out theme) ? theme : ApplicationTheme.Dark;
            }
            set
            {
                helper.Write(nameof(AppTheme), value.ToString());
                (Window.Current.Content as FrameworkElement).RequestedTheme = value.ToElementTheme();
                //Win.Views.Shell.HamburgerMenu.RefreshStyles(value);
            }
        }

        public TimeSpan CacheMaxDuration
        {
            get { return helper.Read<TimeSpan>(nameof(CacheMaxDuration), TimeSpan.FromDays(2)); }
            set
            {
                helper.Write(nameof(CacheMaxDuration), value);
                BootStrapper.Current.CacheMaxDuration = value;
            }
        }
    }
}

