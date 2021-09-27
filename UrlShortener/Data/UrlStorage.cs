using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Interfaces;

namespace UrlShortener.Data
{
    public class UrlStorage : IUrlStorage
    {
        private readonly ConcurrentDictionary<string, string> _dataStore;

        public UrlStorage(ConcurrentDictionary<string, string> dataStore)
        {
            _dataStore = dataStore;
        }
        public void StoreUrl(string key, string url)
        {
            if (string.IsNullOrEmpty(FindKey(url))){
                _dataStore[key] = url;
            }
        }

        public Task<string> RetriveUrl(string key)
        {
            if(_dataStore.ContainsKey(key))
            {
                return Task.FromResult(_dataStore[key]);
            }
            return Task.FromResult(string.Empty);
        }

        private string FindKey(string url)
        {
            return _dataStore.FirstOrDefault(x => x.Value == url).Value;
        }
    }
}
