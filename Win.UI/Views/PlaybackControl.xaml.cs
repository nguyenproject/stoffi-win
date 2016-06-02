using Stoffi.Core.Services;
using Stoffi.Win.Logic.ViewModels;
using Windows.UI.Xaml.Controls;
using Microsoft.Practices.Unity;
using Stoffi.Win.Logic.Services;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace Stoffi.Win.Views
{
    public sealed partial class PlaybackControl : UserControl
    {
        public PlaybackControl()
        {
            this.InitializeComponent();
            var viewModel = DataContext as PlaybackViewModel;
            var service = Container.Instance.Resolve<MediaService>();
            service.WebView = youtubePlayer;
        }
    }
}
