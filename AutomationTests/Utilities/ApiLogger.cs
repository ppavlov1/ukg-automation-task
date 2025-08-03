using RestSharp;
using System;
using System.Text.Json;

namespace AutomationTests.Utilities
{
    public static class ApiLogger
    {
        public static RestResponse<T> LogAndExecute<T>(RestClient client, RestRequest request, object body = null, Func<RestResponse<T>, bool> failCondition = null)
        {
            var response = client.Execute<T>(request);

            if (failCondition != null && failCondition(response))
            {
                LogRequestAndResponse(request, response, body);
            }

            return response;
        }

        private static void LogRequestAndResponse<T>(RestRequest request, RestResponse<T> response, object body = null)
        {
            Console.WriteLine("=== API REQUEST ===");
            Console.WriteLine($"Method: {request.Method}");
            Console.WriteLine($"Endpoint: {request.Resource}");

            if (body != null)
            {
                var json = JsonSerializer.Serialize(body, new JsonSerializerOptions { WriteIndented = true });
                Console.WriteLine("Body:");
                Console.WriteLine(json);
            }

            Console.WriteLine("=== API RESPONSE ===");
            Console.WriteLine($"Status Code: {(int)response.StatusCode}");
            Console.WriteLine("Content:");
            Console.WriteLine(response.Content);
            Console.WriteLine("====================");
        }
    }
}
