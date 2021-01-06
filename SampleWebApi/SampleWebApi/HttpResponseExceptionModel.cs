using System;
using System.Collections.Generic;
using System.Net;

namespace SampleWebApi
{
    
    public class HttpResponseExceptionModel : Exception
    {



        public HttpStatusCode Status { get; set; } = HttpStatusCode.InternalServerError;

        public List<String> ErrorMessages = new List<string>();
        public HttpResponseExceptionModel()
        { }

    }
}
