using Stoffi.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stoffi.Core.Enums;
using System.ComponentModel;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.Prism.Mvvm;
using Stoffi.Core.Models;

namespace Stoffi.Win.Logic.Services
{
    public class MediaService : BindableBase, IMediaService
    {
        public WebView WebView { get; set; }

        private string loadedPath;

        public MediaService()
        {
            WebView = new WebView();
        }

        public TimeSpan CurrentTime
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        private PlaybackQuality preferedQuality = PlaybackQuality.Medium;
        public PlaybackQuality PreferedQuality
        {
            get { return preferedQuality; }
            set { SetProperty(ref preferedQuality, value); }
        }

        public TimeSpan RemainingTime
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public PlaybackState State
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public async void Pause()
        {
            await WebView.InvokeScriptAsync("eval", new string[] { "pauseVideo()" });
        }

        public async void Play(Song song = null)
        {
            var id = song?.GetPathId();
            // resuming
            if (String.IsNullOrWhiteSpace(id) || song.Path == loadedPath)
                await WebView.InvokeScriptAsync("eval", new string[] { "playVideo()" });
            else // new song
            {
                loadedPath = song.Path;
                // BUG: crash when restoring playback state at app startup
                try
                {
                    await WebView.InvokeScriptAsync("eval", new string[] { $"loadVideo('{id}')" });
                }
                catch (Exception ex)
                {
                    // throw unless player still loading
                    if (ex.Message != "Exception from HRESULT: 0x80020101")
                        throw ex;
                }
            }
        }
    }
}
