using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TheSecondTestSolution.Domain.Seed
{
    public class RootExeption : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public IEnumerable<string> Messages { get; }

        public RootExeption(HttpStatusCode statusCode, params string[]  messages)
        {
            StatusCode = statusCode;
            Messages = messages;
        }
    }
}
