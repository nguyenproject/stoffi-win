using Stoffi.Core.Services;
using System;
using Template10.Common;
using Template10.Utils;
using Windows.UI.Xaml;
using Template10.Services.SettingsService;
using Template10.Services.FileService;
using System.Collections.Generic;
using System.Threading.Tasks;

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
        /// A list of setting keys that are large in size and thus needs
        /// to be saved to file instead of the settings storage of UWP.
        /// </summary>
        /// <remarks>
        /// The settings storage of UWP has a 6k limit. Large settings needs to
        /// be saved to file instead.
        /// </remarks>
        public List<string> LargeSettings { get; set; }

        /// <summary>
        /// The strategy to use for storing settings.
        /// </summary>
        public SettingsStrategies Strategy { get; set; }

        /// <summary>
        /// Gets the storage strategy that corresponds to the
        /// current settings strategy.
        /// </summary>
        public StorageStrategies StorageStrategy
        {
            get
            {
                switch (Strategy)
                {
                    case SettingsStrategies.Local:
                        return StorageStrategies.Local;
                    case SettingsStrategies.Temp:
                        return StorageStrategies.Temporary;
                    case SettingsStrategies.Roam:
                    default:
                        return StorageStrategies.Roaming;
                }
            }
        }

        public SettingsStorage(SettingsStrategies strategy = SettingsStrategies.Roam)
        {
            helper = new SettingsHelper();
            LargeSettings = new List<string>();
            Strategy = strategy;
        }

        /// <summary>
        /// Check whether a given setting exists.
        /// </summary>
        /// <param name="name">The name of the record</param>
        /// <returns>True if the setting exists, false otherwise</returns>
        public async Task<bool> Exists(string name)
        {
            if (!LargeSettings.Contains(name))
                return helper.Exists(name, Strategy);
            return await FileHelper.FileExistsAsync(name, StorageStrategy);
        }

        /// <summary>
        /// Read the value of a given setting.
        /// </summary>
        /// <typeparam name="T">The type of the setting</typeparam>
        /// <param name="name">The name of the setting</param>
        /// <param name="otherwise">The default value to return if the setting is not found</param>
        /// <returns>The setting if found, `otherwise` if not</returns>
        public async Task<T> Read<T>(string name, T otherwise)
        {
            if (!LargeSettings.Contains(name))
                return helper.Read<T>(name, otherwise, Strategy);
            var value = await FileHelper.ReadFileAsync<T>(name, StorageStrategy);
            return value == null ? otherwise : value;
        }

        /// <summary>
        /// Remove a given setting.
        /// </summary>
        /// <param name="name">The name of the setting</param>
        public async Task Remove(string name)
        {
            if (!LargeSettings.Contains(name))
                helper.Remove(name, Strategy);
            else
                await FileHelper.DeleteFileAsync(name, StorageStrategy);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Save a setting.
        /// </summary>
        /// <typeparam name="T">The type of the setting</typeparam>
        /// <param name="name">The name of the setting</param>
        /// <param name="value">The value of the setting</param>
        public async Task Write<T>(string name, T value)
        {
            if (!LargeSettings.Contains(name))
                helper.Write<T>(name, value, Strategy);
            else
                await FileHelper.WriteFileAsync<T>(name, value, StorageStrategy);
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

