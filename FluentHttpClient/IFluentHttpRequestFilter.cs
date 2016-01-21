using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    /// <summary>
    /// This interface represents an extension point to FluentHttpRequest
    /// </summary>
    public interface IFluentHttpRequestFilter
    {
        void ProcessRequestMessage(HttpRequestMessage request);
    }
}
