using Template10.Mvvm;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;
using Stoffi.Core.Models;
using Stoffi.Core.Services;
using Windows.UI.Xaml.Controls;

namespace Stoffi.Win.Logic.ViewModels
{
    /// <summary>
    /// Drives the view showing lists of songs.
    /// </summary>
    public class MusicPageViewModel : ViewModelBase
    {
        /// <summary>
        /// Describes the current search state.
        /// </summary>
        public enum SearchState
        {
            /// <summary>
            /// The default state.
            /// </summary>
            VisualStateDefault,

            /// <summary>
            /// State when a search is in progress.
            /// </summary>
            VisualStateLoading,
            
            /// <summary>
            /// State when there are search results to show.
            /// </summary>
            VisualStateResults,

            /// <summary>
            /// State when a search has been performed, but it
            /// resulted in no matches.
            /// </summary>
            VisualStateNoResults
        }

        /// <summary>
        /// The service used for handling search requests.
        /// </summary>
        private readonly ISearchService searchService;
        
        /// <summary>
        /// The maximum number of search suggestions to show.
        /// </summary>
        private const uint maxNumberOfSuggestions = 5;

        private SearchState currentSearchState = SearchState.VisualStateDefault;

        /// <summary>
        /// Create an instance of the class.
        /// </summary>
        public MusicPageViewModel() : this(new SearchService())
        {
        }

        /// <summary>
        /// Create a new instance of the class.
        /// </summary>
        public MusicPageViewModel(ISearchService searchService)
        {
            this.searchService = searchService;
			Results = new ObservableCollection<Song>();
            SearchSuggestions = new ObservableCollection<string>();
            this.SuggestionsCommand = new DelegateCommand<AutoSuggestBoxTextChangedEventArgs>(async (eventArgs) =>
            {
                if (eventArgs.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
                {
                    await GetSearchSuggestions();
                }
            });
            this.SearchCommand = new DelegateCommand<AutoSuggestBoxQuerySubmittedEventArgs>(async (eventArgs) =>
            {
                await SubmitQuery();
            });
            this.SuggestionChosenCommand = new DelegateCommand<AutoSuggestBoxSuggestionChosenEventArgs>(async (eventArgs) =>
            {
                await SubmitQuery();
            });
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        /// <summary>
        /// The command for submitting a search query.
        /// </summary>
        public DelegateCommand<AutoSuggestBoxQuerySubmittedEventArgs> SearchCommand { get; set; }

        /// <summary>
        /// The command for chosing a search suggestion.
        /// </summary>
        public DelegateCommand<AutoSuggestBoxSuggestionChosenEventArgs> SuggestionChosenCommand { get; set; }

        /// <summary>
        /// The command for requesting a list of search query suggestions.
        /// </summary>
        public DelegateCommand<AutoSuggestBoxTextChangedEventArgs> SuggestionsCommand { get; set; }

        /// <summary>
        /// The search query.
        /// </summary>
        public string Query { get; set; }

		/// <summary>
		/// A list of search results.
		/// </summary>
		public ObservableCollection<Song> Results { get; set; }

        /// <summary>
        /// A list of suggestions for search queries.
        /// </summary>
        public ObservableCollection<string> SearchSuggestions { get; set; }

        /// <summary>
        /// Indicates whether search results are being loaded.
        /// </summary>
        public bool IsLoading { get; private set; }

        /// <summary>
        /// Gets or sets the current search state.
        /// </summary>
        public SearchState CurrentSearchState
        {
            get { return currentSearchState; }
            set
            {
                this.Set(ref currentSearchState, value);
            }
        }

        /// <summary>
        /// Submit a search query to the web service.
        /// </summary>
        public async Task SubmitQuery()
        {
            if (String.IsNullOrWhiteSpace(Query))
                return;
            CurrentSearchState = SearchState.VisualStateLoading;
            IsLoading = true;
            try
            {
                Results.Clear();
                var searchResult = await searchService.GetFilteredSongsAsync(Query, 30);
                searchResult.Hits.ForEach(Results.Add);
            }
            catch (Exception ex)
            {
                CurrentSearchState = SearchState.VisualStateDefault;
                throw new Exception("Error searching the web service", ex);
            }
            finally
            {
                IsLoading = false;
                CurrentSearchState = Results.Count == 0 ? SearchState.VisualStateNoResults : SearchState.VisualStateResults;
            }
        }
        
        /// <summary>
        /// Get a list of search query suggestions.
        /// </summary>
        public async Task GetSearchSuggestions()
        {
            var query = Query != null ? Query.Trim() : null;
            if (String.IsNullOrWhiteSpace(query))
                return;
            var suggestions = await searchService.GetSearchSuggestionsAsync(Query);
            SearchSuggestions.Clear();
            foreach (var suggestion in suggestions)
            {
                SearchSuggestions.Add(suggestion.Value);
            }
        }
    }
}

