using Stoffi.Core.Enums;
using Stoffi.Core.Services;
using Microsoft.Practices.Prism.Mvvm;
using Stoffi.Core.Models;
using System.Collections.ObjectModel;

namespace Stoffi.Win.Tests.Unit.Mocks
{
    public class MockPlaybackService : BindableBase, IPlaybackService
    {
        private Song song;
        public Song Song
        {
            get { return song; }
            set { SetProperty(ref song, value); }
        }

        private PlaybackState state = PlaybackState.Paused;
        public PlaybackState State
        {
            get { return state; }
            set { SetProperty(ref state, value); }
        }

        private ObservableCollection<Song> upcoming;
        public ObservableCollection<Song> Upcoming
        {
            get { return upcoming; }
            set { SetProperty(ref upcoming, value); }
        }
    }
}
