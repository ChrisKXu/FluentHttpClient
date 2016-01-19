using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    public class FluentHttpClient : IDisposable
    {
        internal HttpMessageInvoker HttpClient { get; set; }

        internal FluentHttpClientHandler HttpHandler { get; set; }

        /// <summary>
        /// Default contructor, takes no arguments
        /// </summary>
        public FluentHttpClient()
        {
            this.HttpHandler = new FluentHttpClientHandler();
            this.HttpClient = new HttpClient(HttpHandler, false); // nope, we will dispose the handler ourselves
        }

        public FluentHttpRequest CreateHttpRequest()
        {
            return new FluentHttpRequest(this);
        }
        
        public void Dispose()
        {
            this.HttpClient?.Dispose();
            this.HttpHandler?.Dispose();
        }
    }
}
