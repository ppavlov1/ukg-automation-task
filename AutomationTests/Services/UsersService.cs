using RestSharp;
using AutomationTests.Models;

namespace AutomationTests.Services
{
    public class UsersService : ApiConnector
    {
        protected const string Endpoint = "/api/Users";

        public RestResponse<List<UserResponse>> GetAllUsers()
        {
            var request = CreateRequest(Endpoint, Method.Get);
            return Execute<List<UserResponse>>(request);
        }

        public RestResponse<UserResponse> CreateUser(User user)
        {
            var request = CreateRequest(Endpoint, Method.Post);
            request.AddJsonBody(user);
            return Execute<UserResponse>(request, user);
        }

    }
}
