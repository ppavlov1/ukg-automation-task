using RestSharp;
using AutomationTests.Utilities;
using RestSharp.Serializers.NewtonsoftJson;

namespace AutomationTests.Services
{
    public class ApiConnector
    {
        protected readonly RestClient Client;

        public ApiConnector()
        {
            var options = new RestClientOptions(ConfigHelper.BaseUrl)
            {
                ThrowOnAnyError = false,
                Timeout = TimeSpan.FromSeconds(10)
            };

            Client = new RestClient(options, configureSerialization: s => s.UseNewtonsoftJson());
        }

        protected RestRequest CreateRequest(string endpoint, Method method)
        {
            return new RestRequest(endpoint, method);
        }

        protected RestResponse Execute(RestRequest request)
        {
            return Client.Execute(request);
        }

        protected async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            return await Client.ExecuteAsync(request);
        }

        protected RestResponse<T> Execute<T>(RestRequest request, object body = null)
        {
            return ApiLogger.LogAndExecute<T>(
                Client,
                request,
                body,
                failCondition: r => !r.IsSuccessful
            );
        }

    }
}
