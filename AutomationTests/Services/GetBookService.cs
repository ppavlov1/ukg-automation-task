using RestSharp;
using AutomationTests.Models;

namespace AutomationTests.Services
{
    public class GetBookService : ApiConnector
    {
        protected const string Endpoint = "/api/GetBook";

        public RestResponse<List<GetBook>> GetAllBorrowed()
        {
            var request = CreateRequest(Endpoint, Method.Get);
            return Execute<List<GetBook>>(request);
        }

        public RestResponse<GetBookResponse> BorrowBook(GetBook borrow)
        {
            var request = CreateRequest(Endpoint, Method.Post);
            request.AddJsonBody(borrow);
            return Execute<GetBookResponse>(request, borrow);
        }
    }
}
