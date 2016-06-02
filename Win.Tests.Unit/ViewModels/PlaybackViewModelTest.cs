using System.Collections.Generic;
using Stoffi.Core.Models;
using System.Threading.Tasks;
using Stoffi.Win.Logic.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Stoffi.Win.Tests.Unit.Mocks;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;
using Stoffi.Core.Enums;
using FontAwesome.UWP;

namespace Stoffi.Win.Tests.Unit
{
    [TestClass]
    public class PlaybackViewModelTest
    {
        [TestMethod]
        public void ChangeSong_Song_SetCurrentlyPlaying()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            playback.Song = new Song { Name = "A Test Song" };
            Assert.AreEqual("A Test Song", viewModel.CurrentlyPlaying);
        }

        [TestMethod]
        public void ChangeSong_Null_SetCurrentlyPlayingToDefault()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            var defaultLabel = viewModel.CurrentlyPlaying;
            playback.Song = new Song { Name = "A Test Song" };
            playback.Song = null;
            Assert.AreEqual(defaultLabel, viewModel.CurrentlyPlaying);
            Assert.AreEqual("Welcome to Stoffi 2.0 Beta 1", defaultLabel);
        }

        [TestMethod]
        public void ChangeState_SetPlayPauseIcon()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            Assert.AreEqual(FontAwesomeIcon.Play, viewModel.PlayPauseIcon);
            playback.State = PlaybackState.Playing;
            Assert.AreEqual(FontAwesomeIcon.Pause, viewModel.PlayPauseIcon);
            playback.State = PlaybackState.Paused;
            Assert.AreEqual(FontAwesomeIcon.Play, viewModel.PlayPauseIcon);
            playback.State = PlaybackState.Loading;
            Assert.AreEqual(FontAwesomeIcon.Pause, viewModel.PlayPauseIcon);
        }

        [TestMethod]
        public void PlayPause_Paused_ToPlaying()
        {
            var playback = new MockPlaybackService();
            playback.Song = new Song();
            var viewModel = new PlaybackViewModel(playback);
            playback.State = PlaybackState.Paused;
            viewModel.PlayPauseCommand.Execute();
            Assert.AreEqual(PlaybackState.Playing, playback.State);
        }

        [TestMethod]
        public void PlayPause_PausedWithoutSong_ToPaused()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            playback.Song = null;
            playback.State = PlaybackState.Paused;
            viewModel.PlayPauseCommand.Execute();
            Assert.AreEqual(PlaybackState.Paused, playback.State);
        }

        [TestMethod]
        public void PlayPause_Loading_ToPaused()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            playback.State = PlaybackState.Loading;
            viewModel.PlayPauseCommand.Execute();
            Assert.AreEqual(PlaybackState.Paused, playback.State);
        }

        [TestMethod]
        public void PlayPause_Playing_ToPaused()
        {
            var playback = new MockPlaybackService();
            var viewModel = new PlaybackViewModel(playback);
            playback.State = PlaybackState.Playing;
            viewModel.PlayPauseCommand.Execute();
            Assert.AreEqual(PlaybackState.Paused, playback.State);
        }
    }
}
