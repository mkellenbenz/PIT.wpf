﻿using System.ComponentModel.Composition;
using System.Net.Http;
using System.Net.Http.Headers;
using PIT.API.HTTP.Contracts;

namespace PIT.API.HTTP
{
    [Export(typeof(IHttpClient))]
    public class PITHttpClient : IHttpClient
    {
        private readonly IHttpClientProxy _http;

        public PITHttpClient() : this(new HttpClientProxy())
        {
        }

        public PITHttpClient(IHttpClientProxy httpClient)
        {
            _http = httpClient;
            ApplyRequestMediaType();
        }

        private void ApplyRequestMediaType()
        {
            if (_http.DefaultRequestHeaders != null)
                _http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string uri)
        {
            return _http.GetAsync(uri).Result;
        }

        public HttpResponseMessage Put(string uri, HttpContent content)
        {
            return _http.PutAsync(uri, content).Result;
        }

        public HttpResponseMessage Post(string uri, HttpContent content)
        {
            return _http.PostAsync(uri, content).Result;
        }

        public HttpResponseMessage Delete(string uri)
        {
            return _http.DeleteAsync(uri).Result;
        }
    }
}