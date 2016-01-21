using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    public class FluentHttpRequest : IDisposable
    {
        internal FluentHttpClient FluentHttpClient { get; set; }

        internal HttpMessageHandler HttpHandler { get; set; }

        public ICollection<IFluentHttpRequestFilter> RequestFilters { get; private set; }

        internal FluentHttpRequest(FluentHttpClient httpClient)
        {
            FluentHttpClient = httpClient;
            RequestFilters = new List<IFluentHttpRequestFilter>();
        }

        public virtual Task<FluentHttpResponse> SendAsync()
        {
            return SendAsync(CancellationToken.None);
        }

        /// <summary>
        /// Send http request and return a FluentHttpResponse object for further processing
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async virtual Task<FluentHttpResponse> SendAsync(CancellationToken cancellationToken)
        {
            if (HttpHandler == null)
            {
                throw new ArgumentNullException(nameof(HttpHandler));
            }

            var requestMessage = new HttpRequestMessage();
            foreach (var filter in RequestFilters)
            {
                filter.ProcessRequestMessage(requestMessage);
            }

            cancellationToken.ThrowIfCancellationRequested();

            using (var httpClient = new HttpClient(HttpHandler, false))
            {
                var responseMessage = await httpClient.SendAsync(requestMessage).ConfigureAwait(false);
                return new FluentHttpResponse(responseMessage);
            }
        }

        public void Dispose()
        {
            HttpHandler?.Dispose();
        }
    }
}
