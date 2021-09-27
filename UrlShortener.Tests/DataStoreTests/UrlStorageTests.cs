using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Data;
using Xunit;

namespace UrlShortener.Tests.DataStoreTests
{
    public class UrlStorageTests
    {
        [Fact]
        public async void StoringUrl_ReturnsString()
        {
            //Arange
            var fakeData = new ConcurrentDictionary<string, string>();
            var fakeKey = "xFFF=";
            var fakeUrl = "https://www.musclefood.com/build-your-own-box-50";
            //Act
            var cut = new UrlStorage(fakeData);
            cut.StoreUrl(fakeKey, fakeUrl);
            //Assert
            Assert.Equal(fakeUrl, await cut.RetriveUrl(fakeKey));
        }

        [Fact]
        public async void StoringUrl_ReturnsEmptyString()
        {
            //Arange
            var fakeData = new ConcurrentDictionary<string, string>();
            var fakeKey = "xFFF=";
            //Act
            var cut = new UrlStorage(fakeData);
            //Assert
            Assert.Equal(string.Empty, await cut.RetriveUrl(fakeKey));
        }
    }
}
