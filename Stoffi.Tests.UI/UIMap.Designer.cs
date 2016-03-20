﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by coded UI test builder.
//      Version: 14.0.0.0
//
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------

namespace Stoffi.Tests.UI
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITest.Input;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = Microsoft.VisualStudio.TestTools.UITest.Input.MouseButtons;
    
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public partial class UIMap
    {
        
        /// <summary>
        /// Verify that the navigation items exists.
        /// </summary>
        public void NavigationExists()
        {
            #region Variable Declarations
            XamlListItem uIStoffiCoreViewModelsListItemDashboard = this.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemDashboard;
            XamlListItem uIStoffiCoreViewModelsListItemPlaylists = this.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemPlaylists;
            XamlListItem uIStoffiCoreViewModelsListItemMusic = this.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemMusic;
            XamlListItem uIStoffiCoreViewModelsListItemTimeline = this.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemTimeline;
            XamlListItem uIStoffiCoreViewModelsListItemSettings = this.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemSettings;
            #endregion

            // Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.DashboardViewMode...' list item equals 'True'
            Assert.AreEqual(this.NavigationExistsExpectedValues.UIStoffiCoreViewModelsListItemDashboardExists, uIStoffiCoreViewModelsListItemDashboard.Exists, "Dashboard item does not exist");

            // Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.PlaylistsViewMode...' list item equals 'True'
            Assert.AreEqual(this.NavigationExistsExpectedValues.UIStoffiCoreViewModelsListItemPlaylistsExists, uIStoffiCoreViewModelsListItemPlaylists.Exists, "Playlists item does not exist");

            // Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.MusicViewModel' list item equals 'True'
            Assert.AreEqual(this.NavigationExistsExpectedValues.UIStoffiCoreViewModelsListItemMusicExists, uIStoffiCoreViewModelsListItemMusic.Exists, "Music item does not exist");

            // Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.TimelineViewModel' list item equals 'True'
            Assert.AreEqual(this.NavigationExistsExpectedValues.UIStoffiCoreViewModelsListItemTimelineExists, uIStoffiCoreViewModelsListItemTimeline.Exists, "Timeline item does not exist");

            // Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.SettingsViewModel' list item equals 'True'
            Assert.AreEqual(this.NavigationExistsExpectedValues.UIStoffiCoreViewModelsListItemSettingsExists, uIStoffiCoreViewModelsListItemSettings.Exists, "Settings item does not exist");
        }
        
        #region Properties
        public virtual NavigationExistsExpectedValues NavigationExistsExpectedValues
        {
            get
            {
                if ((this.mNavigationExistsExpectedValues == null))
                {
                    this.mNavigationExistsExpectedValues = new NavigationExistsExpectedValues();
                }
                return this.mNavigationExistsExpectedValues;
            }
        }
        
        public UIStoffiWindow UIStoffiWindow
        {
            get
            {
                if ((this.mUIStoffiWindow == null))
                {
                    this.mUIStoffiWindow = new UIStoffiWindow();
                }
                return this.mUIStoffiWindow;
            }
        }
        #endregion
        
        #region Fields
        private NavigationExistsExpectedValues mNavigationExistsExpectedValues;
        
        private UIStoffiWindow mUIStoffiWindow;
        #endregion
    }
    
    /// <summary>
    /// Parameters to be passed into 'NavigationExists'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class NavigationExistsExpectedValues
    {
        
        #region Fields
        /// <summary>
        /// Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.DashboardViewMode...' list item equals 'True'
        /// </summary>
        public bool UIStoffiCoreViewModelsListItemDashboardExists = true;
        
        /// <summary>
        /// Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.PlaylistsViewMode...' list item equals 'True'
        /// </summary>
        public bool UIStoffiCoreViewModelsListItemPlaylistsExists = true;
        
        /// <summary>
        /// Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.MusicViewModel' list item equals 'True'
        /// </summary>
        public bool UIStoffiCoreViewModelsListItemMusicExists = true;
        
        /// <summary>
        /// Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.TimelineViewModel' list item equals 'True'
        /// </summary>
        public bool UIStoffiCoreViewModelsListItemTimelineExists = true;
        
        /// <summary>
        /// Verify that the 'Exists' property of 'Stoffi.Core.ViewModels.Interface.SettingsViewModel' list item equals 'True'
        /// </summary>
        public bool UIStoffiCoreViewModelsListItemSettingsExists = true;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIStoffiWindow : XamlWindow
    {
        
        public UIStoffiWindow()
        {
            #region Search Criteria
            this.SearchProperties[XamlControl.PropertyNames.Name] = "Stoffi";
            this.SearchProperties[XamlControl.PropertyNames.ClassName] = "Windows.UI.Core.CoreWindow";
            this.WindowTitles.Add("Stoffi");
            #endregion
        }
        
        #region Properties
        public UIListBoxList UIListBoxList
        {
            get
            {
                if ((this.mUIListBoxList == null))
                {
                    this.mUIListBoxList = new UIListBoxList(this);
                }
                return this.mUIListBoxList;
            }
        }
        
        public XamlText UIDashboardText
        {
            get
            {
                if ((this.mUIDashboardText == null))
                {
                    this.mUIDashboardText = new XamlText(this);
                    #region Search Criteria
                    this.mUIDashboardText.SearchProperties[XamlText.PropertyNames.Name] = "Dashboard";
                    this.mUIDashboardText.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIDashboardText;
            }
        }
        
        public XamlText UIPlaylistsText
        {
            get
            {
                if ((this.mUIPlaylistsText == null))
                {
                    this.mUIPlaylistsText = new XamlText(this);
                    #region Search Criteria
                    this.mUIPlaylistsText.SearchProperties[XamlText.PropertyNames.Name] = "Playlists";
                    this.mUIPlaylistsText.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIPlaylistsText;
            }
        }
        
        public XamlText UIMusicText
        {
            get
            {
                if ((this.mUIMusicText == null))
                {
                    this.mUIMusicText = new XamlText(this);
                    #region Search Criteria
                    this.mUIMusicText.SearchProperties[XamlText.PropertyNames.Name] = "Music";
                    this.mUIMusicText.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIMusicText;
            }
        }
        
        public XamlText UITimelineText
        {
            get
            {
                if ((this.mUITimelineText == null))
                {
                    this.mUITimelineText = new XamlText(this);
                    #region Search Criteria
                    this.mUITimelineText.SearchProperties[XamlText.PropertyNames.Name] = "Timeline";
                    this.mUITimelineText.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUITimelineText;
            }
        }
        
        public XamlText UISettingsText
        {
            get
            {
                if ((this.mUISettingsText == null))
                {
                    this.mUISettingsText = new XamlText(this);
                    #region Search Criteria
                    this.mUISettingsText.SearchProperties[XamlText.PropertyNames.Name] = "Settings";
                    this.mUISettingsText.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUISettingsText;
            }
        }
        #endregion
        
        #region Fields
        private UIListBoxList mUIListBoxList;
        
        private XamlText mUIDashboardText;
        
        private XamlText mUIPlaylistsText;
        
        private XamlText mUIMusicText;
        
        private XamlText mUITimelineText;
        
        private XamlText mUISettingsText;
        #endregion
    }
    
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class UIListBoxList : XamlList
    {
        
        public UIListBoxList(XamlControl searchLimitContainer) : 
                base(searchLimitContainer)
        {
            #region Search Criteria
            this.SearchProperties[XamlList.PropertyNames.AutomationId] = "listBox";
            this.WindowTitles.Add("Stoffi");
            #endregion
        }
        
        #region Properties
        public XamlListItem UIStoffiCoreViewModelsListItemDashboard
        {
            get
            {
                if ((this.mUIStoffiCoreViewModelsListItemDashboard == null))
                {
                    this.mUIStoffiCoreViewModelsListItemDashboard = new XamlListItem(this);
                    #region Search Criteria
                    this.mUIStoffiCoreViewModelsListItemDashboard.SearchProperties[XamlListItem.PropertyNames.Name] = "Stoffi.Core.ViewModels.Interface.DashboardViewModel";
                    this.mUIStoffiCoreViewModelsListItemDashboard.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIStoffiCoreViewModelsListItemDashboard;
            }
        }
        
        public XamlListItem UIStoffiCoreViewModelsListItemPlaylists
        {
            get
            {
                if ((this.mUIStoffiCoreViewModelsListItemPlaylists == null))
                {
                    this.mUIStoffiCoreViewModelsListItemPlaylists = new XamlListItem(this);
                    #region Search Criteria
                    this.mUIStoffiCoreViewModelsListItemPlaylists.SearchProperties[XamlListItem.PropertyNames.Name] = "Stoffi.Core.ViewModels.Interface.PlaylistsViewModel";
                    this.mUIStoffiCoreViewModelsListItemPlaylists.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIStoffiCoreViewModelsListItemPlaylists;
            }
        }
        
        public XamlListItem UIStoffiCoreViewModelsListItemMusic
        {
            get
            {
                if ((this.mUIStoffiCoreViewModelsListItemMusic == null))
                {
                    this.mUIStoffiCoreViewModelsListItemMusic = new XamlListItem(this);
                    #region Search Criteria
                    this.mUIStoffiCoreViewModelsListItemMusic.SearchProperties[XamlListItem.PropertyNames.Name] = "Stoffi.Core.ViewModels.Interface.MusicViewModel";
                    this.mUIStoffiCoreViewModelsListItemMusic.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIStoffiCoreViewModelsListItemMusic;
            }
        }
        
        public XamlListItem UIStoffiCoreViewModelsListItemTimeline
        {
            get
            {
                if ((this.mUIStoffiCoreViewModelsListItemTimeline == null))
                {
                    this.mUIStoffiCoreViewModelsListItemTimeline = new XamlListItem(this);
                    #region Search Criteria
                    this.mUIStoffiCoreViewModelsListItemTimeline.SearchProperties[XamlListItem.PropertyNames.Name] = "Stoffi.Core.ViewModels.Interface.TimelineViewModel";
                    this.mUIStoffiCoreViewModelsListItemTimeline.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIStoffiCoreViewModelsListItemTimeline;
            }
        }
        
        public XamlListItem UIStoffiCoreViewModelsListItemSettings
        {
            get
            {
                if ((this.mUIStoffiCoreViewModelsListItemSettings == null))
                {
                    this.mUIStoffiCoreViewModelsListItemSettings = new XamlListItem(this);
                    #region Search Criteria
                    this.mUIStoffiCoreViewModelsListItemSettings.SearchProperties[XamlListItem.PropertyNames.Name] = "Stoffi.Core.ViewModels.Interface.SettingsViewModel";
                    this.mUIStoffiCoreViewModelsListItemSettings.WindowTitles.Add("Stoffi");
                    #endregion
                }
                return this.mUIStoffiCoreViewModelsListItemSettings;
            }
        }
        #endregion
        
        #region Fields
        private XamlListItem mUIStoffiCoreViewModelsListItemDashboard;
        
        private XamlListItem mUIStoffiCoreViewModelsListItemPlaylists;
        
        private XamlListItem mUIStoffiCoreViewModelsListItemMusic;
        
        private XamlListItem mUIStoffiCoreViewModelsListItemTimeline;
        
        private XamlListItem mUIStoffiCoreViewModelsListItemSettings;
        #endregion
    }
}