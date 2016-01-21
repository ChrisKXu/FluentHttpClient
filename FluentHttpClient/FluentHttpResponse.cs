using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FluentHttpClient
{
    /// <summary>
    /// This class wraps around HttpResponseMessage for fluent processing
    /// </summary>
    public class FluentHttpResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; private set; }

        public FluentHttpResponse(HttpResponseMessage responseMessage)
        {
            HttpResponseMessage = responseMessage;
        }
    }
}
