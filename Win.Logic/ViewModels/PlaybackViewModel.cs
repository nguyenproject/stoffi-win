using Stoffi.Core.Services;
using Microsoft.Practices.Unity;
using Template10.Mvvm;
using Stoffi.Core.Models;
using Stoffi.Core.Enums;
using FontAwesome.UWP;
using System.Windows.Input;
using System;

namespace Stoffi.Win.Logic.ViewModels
{
    public class PlaybackViewModel : ViewModelBase
    {
        /// <summary>
        /// Service used for managing playback.
        /// </summary>
        private readonly IPlaybackService playbackService;

        private string defaultLabel = "Welcome to Stoffi 2.0 Beta 1";
        private string currentlyPlaying;

        /// <summary>
        /// String describing the currently playing song.
        /// </summary>
        public string CurrentlyPlaying
        {
            get { return currentlyPlaying; }
            private set
            {
                Set<string>(ref currentlyPlaying, value);
            }
        }

        private PlaybackState state = PlaybackState.Paused;
        /// <summary>
        /// String describing the current state of the media playback.
        /// </summary>
        public PlaybackState State
        {
            get { return state; }
            private set
            {
                Set<PlaybackState>(ref state, value);
            }
        }

        private FontAwesomeIcon playPauseIcon = FontAwesomeIcon.Play;
        /// <summary>
        /// The icon to show on the Play/Pause button.
        /// </summary>
        public FontAwesomeIcon PlayPauseIcon
        {
            get { return playPauseIcon; }
            private set
            {
                Set<FontAwesomeIcon>(ref playPauseIcon, value);
            }
        }
        
        public DelegateCommand PlayPauseCommand { get; set; }

        /// <summary>
        /// Create a new instance of the class.
        /// </summary>
        public PlaybackViewModel() : this(Container.Instance.Resolve<IPlaybackService>())
        {
        }

        /// <summary>
        /// Create a new instance of the class.
        /// </summary>
        public PlaybackViewModel(IPlaybackService playback)
        {
            playbackService = playback;
            playbackService.PropertyChanged += PlaybackService_PropertyChanged;
            PlayPauseCommand = new DelegateCommand(() => PlayPause());

            // doubled
            var label = playbackService.Song?.Name ?? defaultLabel;
            CurrentlyPlaying = label;
            State = playbackService.State;
            if (playbackService.State == PlaybackState.Paused)
                PlayPauseIcon = FontAwesomeIcon.Play;
            else
                PlayPauseIcon = FontAwesomeIcon.Pause;
        }

        /// <summary>
        /// Called when a property of the playback service changes.
        /// </summary>
        /// <param name="sender">The sender of the event</param>
        /// <param name="e">The event arguments</param>
        private void PlaybackService_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Song":
                    var label = playbackService.Song?.Name ?? defaultLabel;
                    CurrentlyPlaying = label;
                    break;

                case "State":
                    // REFACTOR: better way to bind property of service and viewmodel
                    State = playbackService.State;
                    if (playbackService.State == PlaybackState.Paused)
                        PlayPauseIcon = FontAwesomeIcon.Play;
                    else
                        PlayPauseIcon = FontAwesomeIcon.Pause;
                    break;
            }
        }

        /// <summary>
        /// Toggle between play and pause state.
        /// </summary>
        private void PlayPause()
        {
            if (playbackService.State == PlaybackState.Paused && playbackService.Song != null)
                playbackService.State = PlaybackState.Playing;
            else
                playbackService.State = PlaybackState.Paused;
        }
    }
}
