using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Dtos;

namespace UrlShortener.Interfaces
{
    public interface IUrlModifierService
    {
        Task<ShortenedUrlDto> EncodeUrl(UrlDto urlDto);
        Task<UrlDto> DecodeUrl(ShortenedUrlDto urlDto);
    }
}
