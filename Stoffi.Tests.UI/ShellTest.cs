using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WindowsRuntimeControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stoffi.Tests.UI
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest(CodedUITestType.WindowsStore)]
    public class ShellTest
    {
        private XamlWindow window;

        public ShellTest()
        {
        }

        [TestMethod]
        public void NavigationExists()
        {
            this.UIMap.NavigationExists();
        }

        [TestMethod]
        public void CanNavigate()
        {
            // dashboard
            Gesture.Tap(UIMap.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemDashboard);
            AssertVisibility(true, UIMap.UIStoffiWindow.UIDashboardText, "Dashboard not visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIPlaylistsText, "Playlists still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIMusicText, "Music still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UITimelineText, "Timeline still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UISettingsText, "Settings still visible");

            // playlists
            Gesture.Tap(UIMap.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemPlaylists);
            AssertVisibility(false, UIMap.UIStoffiWindow.UIDashboardText, "Dashboard still visible");
            AssertVisibility(true, UIMap.UIStoffiWindow.UIPlaylistsText, "Playlists not visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIMusicText, "Music still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UITimelineText, "Timeline still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UISettingsText, "Settings still visible");

            // music
            Gesture.Tap(UIMap.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemMusic);
            AssertVisibility(false, UIMap.UIStoffiWindow.UIDashboardText, "Dashboard still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIPlaylistsText, "Playlists still visible");
            AssertVisibility(true, UIMap.UIStoffiWindow.UIMusicText, "Music not visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UITimelineText, "Timeline still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UISettingsText, "Settings still visible");

            // timeline
            Gesture.Tap(UIMap.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemTimeline);
            AssertVisibility(false, UIMap.UIStoffiWindow.UIDashboardText, "Dashboard still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIPlaylistsText, "Playlists still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIMusicText, "Music still visible");
            AssertVisibility(true, UIMap.UIStoffiWindow.UITimelineText, "Timeline not visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UISettingsText, "Settings still visible");

            // settings
            Gesture.Tap(UIMap.UIStoffiWindow.UIListBoxList.UIStoffiCoreViewModelsListItemSettings);
            AssertVisibility(false, UIMap.UIStoffiWindow.UIDashboardText, "Dashboard still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIPlaylistsText, "Playlists still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UIMusicText, "Music still visible");
            AssertVisibility(false, UIMap.UIStoffiWindow.UITimelineText, "Timeline still visible");
            AssertVisibility(true, UIMap.UIStoffiWindow.UISettingsText, "Settings not visible");
        }

        private void AssertVisibility(bool shouldBeVisible, XamlText control, string message)
        {
            var expected = shouldBeVisible ? ControlStates.ReadOnly : ControlStates.ReadOnly | ControlStates.Offscreen;
            try
            {
                Assert.AreEqual(expected, control.State, message);
            }
            catch (UITestControlNotFoundException)
            {
                Assert.AreEqual(false, shouldBeVisible, message);
            }
        }

        #region Additional test attributes

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void Setup()
        {
            window = XamlWindow.Launch("Simplare.Stoffi_8dr4fy9sf7jpa!App");
            Playback.Wait(500);
            //Assert.IsTrue(window.Exists, "Could not launch app before testing");
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void Teardown()
        {
            if (window != null)
                window.Close();
        }

        #endregion Additional test attributes

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        private TestContext testContextInstance;

        public UIMap UIMap
        {
            get
            {
                if ((this.map == null))
                {
                    this.map = new UIMap();
                }

                return this.map;
            }
        }

        private UIMap map;
    }
}