﻿// Copyright (c) 2016 John Shu

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE

using System;
#if WINDOWS_UWP
using Windows.Web.Http;
using Windows.Web.Http.Filters;
#else
using System.Net.Http;
#endif

namespace Unicorn.ServiceModel
{
    public class HttpClientContainer
    {
        private static Lazy<HttpClient> httpClientInstance = new Lazy<HttpClient>(() =>
        {
#if WINDOWS_UWP
            var httpFilter = new HttpBaseProtocolFilter();
            httpFilter.CacheControl.ReadBehavior = HttpCacheReadBehavior.MostRecent;
            httpFilter.CacheControl.WriteBehavior = HttpCacheWriteBehavior.NoCache;
            return new HttpClient(httpFilter);
#else
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.CacheControl = new System.Net.Http.Headers.CacheControlHeaderValue();
            httpClient.DefaultRequestHeaders.CacheControl.NoCache = true;
            return httpClient;
#endif
        });

        public static HttpClient Get()
        {
            return httpClientInstance.Value;
        }
    }
}