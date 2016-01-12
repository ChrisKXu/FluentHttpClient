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

        /// <summary>
        /// Default contructor, takes no arguments
        /// </summary>
        public FluentHttpClient()
            : this(new HttpClient())
        {
        }

        internal FluentHttpClient(HttpMessageInvoker httpClient)
        {
            // internal constructor for test purposes
            HttpClient = httpClient;
        }

        public FluentHttpRequest CreateHttpRequest()
        {
            return new FluentHttpRequest(this);
        }
        
        public void Dispose()
        {
            HttpClient?.Dispose();
        }
    }
}
