using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    /// <summary>
    /// This class acts like a factory for FluentHttpRequest
    /// </summary>
    public class FluentHttpClient
    {
        /// <summary>
        /// Default contructor, takes no arguments
        /// </summary>
        public FluentHttpClient()
        {

        }

        /// <summary>
        /// Creates a FluentHttpRequest object to send http requests
        /// </summary>
        /// <returns></returns>
        public FluentHttpRequest CreateHttpRequest()
        {
            return new FluentHttpRequest(this)
            {
                HttpHandler = new FluentHttpClientHandler()
            };
        }
    }
}
