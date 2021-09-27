using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrlShortener.Dtos;
using UrlShortener.Interfaces;

namespace UrlShortener.Services
{
    public class UrlModifierService : IUrlModifierService
    {
        private IUrlStorage _urlStorage;
        public UrlModifierService(IUrlStorage urlStorage)
        {
            _urlStorage = urlStorage;
        }
        public Task<UrlDto> DecodeUrl(ShortenedUrlDto urlDto)
        {
            throw new NotImplementedException();
        }

        public Task<ShortenedUrlDto> EncodeUrl(UrlDto urlDto)
        {
            try
            {
                var valueBytes = Encoding.UTF8.GetBytes(urlDto.Url);
                var EncodedUrl = Convert.ToBase64String(valueBytes);
                _urlStorage.StoreUrl(EncodedUrl, urlDto.Url);
                return Task.FromResult(new ShortenedUrlDto { ShortenedUrl = EncodedUrl });
            }
            catch (Exception)
            {
                //log
                return Task.FromResult(new ShortenedUrlDto { ShortenedUrl = string.Empty });
            }
            
        }
    }
}
