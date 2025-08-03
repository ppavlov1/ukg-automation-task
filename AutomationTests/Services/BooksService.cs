using AutomationTests.Models;
using RestSharp;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace AutomationTests.Services
{
    public class BooksService : ApiConnector
    {
        protected const string Endpoint = "/api/Books";

        public RestResponse<List<BookResponse>> GetAllBooks()
        {
            var request = CreateRequest(Endpoint, Method.Get);
            return Execute<List<BookResponse>>(request);
        }

        public RestResponse<BookResponse> CreateBook(Book book)
        {
            var request = CreateRequest(Endpoint, Method.Post);
            request.AddJsonBody(book);
            return Execute<BookResponse>(request, book);
        }
    }
}
