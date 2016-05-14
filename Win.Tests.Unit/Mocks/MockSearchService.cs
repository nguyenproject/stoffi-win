using Stoffi.Core.Services;
using System;
using System.Threading.Tasks;
using Stoffi.Core.Models;
using System.Collections.Generic;

namespace Stoffi.Win.Tests.Unit.Mocks
{
    /// <summary>
    /// A mock of the SearchService, allowing the caller to specify what
    /// the various methods should return.
    /// </summary>
    public class MockSearchService : ISearchService
    {
        public Func<string, int, Task<SearchResult>> GetFilteredSongsAsyncDelegate { get; set; }
        public Func<string, Task<IReadOnlyCollection<SearchSuggestion>>> GetSearchSuggestionsAsyncDelegate { get; set; }

        public Task<SearchResult> GetFilteredSongsAsync(string searchQuery, int maxResults)
        {
            return GetFilteredSongsAsyncDelegate(searchQuery, maxResults);
        }

        public Task<IReadOnlyCollection<SearchSuggestion>> GetSearchSuggestionsAsync(string searchQuery)
        {
            return GetSearchSuggestionsAsyncDelegate(searchQuery);
        }
    }
}
