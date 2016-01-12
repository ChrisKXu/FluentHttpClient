using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    public class FluentHttpRequest
    {
        internal FluentHttpClient HttpClient { get; set; }

        internal FluentHttpRequest(FluentHttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public virtual Task<FluentHttpResponse> SendAsync()
        {
            return SendAsync(CancellationToken.None);
        }

        public virtual Task<FluentHttpResponse> SendAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
