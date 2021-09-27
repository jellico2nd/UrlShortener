using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlShortener.Interfaces
{
    public interface IUrlStorage
    {
        void StoreUrl(string key,string url);
        Task<string> RetriveUrl(string key);
    }
}
