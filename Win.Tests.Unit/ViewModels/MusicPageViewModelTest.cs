using System.Collections.Generic;
using Stoffi.Core.Models;
using System.Threading.Tasks;
using Stoffi.Win.Logic.ViewModels;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Stoffi.Win.Tests.Unit.Mocks;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml.Controls;

namespace Stoffi.Win.Tests.Unit
{
    [TestClass]
    public class MusicPageViewModelTest
    {
        [TestMethod]
        public async Task SubmitQuery_QueryPresent_CallsService()
        {
            var service = new MockSearchService();
            service.GetFilteredSongsAsyncDelegate = MockGetFilteredSongsAsync;
            var viewModel = new MusicPageViewModel(service);
            viewModel.Query = "bob";
            await viewModel.SubmitQuery();
            Assert.AreEqual(2, viewModel.Results.Count);
            Assert.AreEqual("One Love", viewModel.Results[0].Name);
            Assert.IsFalse(viewModel.IsLoading);
        }

        [TestMethod]
        public async Task SubmitQuery_NoQuery_DoesNothing()
        {
            var service = new MockSearchService();
            service.GetFilteredSongsAsyncDelegate = MockGetFilteredSongsAsync;
            var viewModel = new MusicPageViewModel(service);
            viewModel.Query = "";
            await viewModel.SubmitQuery();
            Assert.AreEqual(0, viewModel.Results.Count);
            Assert.IsFalse(viewModel.IsLoading);
        }

        [TestMethod]
        public async Task GetSearchSuggestions_LongQuery_CallsService()
        {
            var service = new MockSearchService();
            service.GetSearchSuggestionsAsyncDelegate = MockGetSearchSuggestionsAsync;
            var viewModel = new MusicPageViewModel(service);
            viewModel.Query = "lov";
            await viewModel.GetSearchSuggestions();
            Assert.AreEqual(2, viewModel.SearchSuggestions.Count);
            Assert.AreEqual("loveboy", viewModel.SearchSuggestions[1]);
        }

        #region Private
        private Task<SearchResult> MockGetFilteredSongsAsync(string query, int max)
        {
            var songs = new List<Song>();
            songs.Add(new Song { Id = 123, Name = "One Love" });
            songs.Add(new Song { Id = 321, Name = "Jamming" });
            if (query != "bob")
                songs.Add(new Song { Id = 456, Name = "Stan" });
            return Task.FromResult(new SearchResult(songs.Count, songs));
        }

        private Task<IReadOnlyCollection<SearchSuggestion>> MockGetSearchSuggestionsAsync(string query)
        {
            var suggestions = new List<SearchSuggestion>();
            suggestions.Add(new SearchSuggestion { Value = "love", Score = 1.5 });
            suggestions.Add(new SearchSuggestion { Value = "loveboy", Score = 1.0 });
            if (query != "lov")
                suggestions.Add(new SearchSuggestion { Value = "low", Score = 0.5 });
            var collection = new ReadOnlyCollection<SearchSuggestion>(suggestions);
            return Task.FromResult((IReadOnlyCollection<SearchSuggestion>)collection);
        }
        #endregion
    }
}
